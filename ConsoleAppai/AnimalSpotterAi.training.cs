﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Vision;
using Microsoft.ML;

namespace ConsoleAppai
{
    public partial class AnimalSpotterAi
    {


        /// <summary>
        ///  Load an IDataView from a folder path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="folder"> Folder to the image data for training.</param>
        public static IDataView LoadImageFromFolder(MLContext mlContext, string folder)
        {
            var res = new List<ModelInput>();
            var allowedImageExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(folder);
            DirectoryInfo[] subDirectories = rootDirectoryInfo.GetDirectories();

            if (subDirectories.Length == 0)
            {
                throw new Exception("fail to find subdirectories");
            }
            
            foreach (DirectoryInfo directory in subDirectories)
            {
                var imageList = directory.EnumerateFiles().Where(f => allowedImageExtensions.Contains(f.Extension.ToLower()));
                if (imageList.Count() > 0)
                {
                    res.AddRange(imageList.Select(i => new ModelInput 
                    {
                        Label = directory.Name,
                         ImageSource = File.ReadAllBytes(i.FullName),
                    }));
                }
            }
            return mlContext.Data.LoadFromEnumerable(res);
        }

        /// <summary>
        /// Retrain model using the pipeline generated as part of the training process.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainModel(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"Label",inputColumnName:@"Label",addKeyValueAnnotationsAsText:false)      
                                    .Append(mlContext.MulticlassClassification.Trainers.ImageClassification(labelColumnName:@"Label",scoreColumnName:@"Score",featureColumnName:@"ImageSource"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
 }
