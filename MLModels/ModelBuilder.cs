using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Ccog3nt_product_Management_4._0.MLModels;
using finalML.Data;
using Microsoft.ML.Trainers;


namespace Ccog3nt_product_Management_4._0.MLModels
{
    public class ModelBuilder
    {
        private static string dataPath;
        private static string modelFile = ConsumeModel.MLNetModelPath;


        private static void CreateModel()
        {
            ModelInput input = new ModelInput();
            string folder = @"../../../clusterUploads";
            DirectoryInfo direc = new DirectoryInfo(folder);
            string fileName = direc.GetFiles().Select(fi => fi.Name).First();
            string filePath = Path.Combine(folder, fileName);
            dataPath = filePath;
            // instantiating a machine learning context
            var context = new MLContext();

            // loading the product data into memory
            Console.WriteLine("Loading data...");
            var data = context.Data.LoadFromTextFile<ModelInput>(
                dataPath,
                hasHeader: true,
                separatorChar: '\t');

            // spliting the data into 80% training (to learn about the products) and 20% testing divisions
            var divisions = context.Data.TrainTestSplit(data, testFraction: 0.2);

            // using matrix factorisation to predict elements 
            var options = new MatrixFactorizationTrainer.Options()
            {
                MatrixColumnIndexColumnName = "ProdIDAEncoded",
                MatrixRowIndexColumnName = "ProdIDBEncoded",
                LabelColumnName = "ProdIDB",
                LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                Alpha = 0.01,
                Lambda = 0.025,


            };

            // setting up a training machine learning workflow/pipeline
            // mapping the product IDS
            var pipeline = context.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "ProdIDA",
                    outputColumnName: "ProdIDAEncoded")
                .Append(context.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "ProdIDB",
                    outputColumnName: "ProdIDBEncoded")

                // step 2: using matrix factorisation, find recommendations 
                .Append(context.Recommendation().Trainers.MatrixFactorization(options)));

            var est = context.Recommendation().Trainers.MatrixFactorization(options);
            // training the model
            Console.WriteLine("Training the model...");

            //ITransformer model = est.Fit(data);

            ITransformer model = pipeline.Fit(divisions.TrainSet);
            Console.WriteLine();


            // choosing products 344 and 63 to assess how well they can be grouped together
            Console.WriteLine("Predicting if your chosen products combine...");
            var engine = context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
            var prediction = engine.Predict(
                new ModelInput()
                {
                    ProdIDA = input.ProdIDA,
                    ProdIDB = input.ProdIDB
                });
            Console.WriteLine($"  Here is the prediction score of products 344 and 63 combined: {prediction.Score}");
            Console.WriteLine();

            Console.WriteLine("Saving the model...");
            context.Model.Save(model, data.Schema, modelFile /*"../../../MLModels/MLModel.zip"*/);

        }
    }
}
