using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Data;

namespace Algorithm
{
    class Program


    {
        //This section specifies the path, name  of the input data

        private static string BaseDataSetRelativePath = @"../../../Data";
        private static string dataPath = $"{BaseDataSetRelativePath}/modified clustered data.txt";
        private static string dataPath2 = $"{BaseDataSetRelativePath}/ProductsInfo.txt";
        static void Main(string[] args)
        {
            CreateModel();
        }   
      
        private static void CreateModel()
        {
            // instantiating a machine learning context
            var context = new MLContext();

            // loading the product data, as a specified model, into memory
            Console.WriteLine("Loading data...");
            var data = context.Data.LoadFromTextFile<ModelInput>(
                dataPath,
                hasHeader: true,
                separatorChar: '\t');

            // spliting the data into 80% training and 20% testing divisions inorder to learn more about the products.
            var divisions = context.Data.TrainTestSplit(data, testFraction: 0.2);

            // using matrix factorisation to predict elements/products for scoring and recommendation
            var options = new MatrixFactorizationTrainer.Options()
            {
                MatrixColumnIndexColumnName = "ProdIDAEncoded",
                MatrixRowIndexColumnName = "ProdIDBEncoded",
                LabelColumnName = "ProdIDB",
                LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                Alpha = 0.01,
                Lambda = 0.025,


            };

            // setting up a training machine learning workflow/pipeline (writing and executing this algorithm inorder to produce a ML model.
            // mapping the product IDS
            var pipeline = context.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "ProdIDA",
                    outputColumnName: "ProdIDAEncoded")
                .Append(context.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "ProdIDB",
                    outputColumnName: "ProdIDBEncoded")

              // calling this  matrix factorisation algorithm to find recommendations and assigning then to a variable 
              .Append(context.Recommendation().Trainers.MatrixFactorization(options)));

            var est = context.Recommendation().Trainers.MatrixFactorization(options);
            // training the model
            Console.WriteLine("Training the model...");

            //Calling the relevant classes to train the model(learning more about the data inorder to provide accurate results)
            ITransformer model = pipeline.Fit(divisions.TrainSet);
            Console.WriteLine();


            // choosing two products to assess how well they can be grouped (recommended) together
            Console.WriteLine("Predicting if your chosen products combine...");
            var engine = context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
            //calling the predict method for these 2 products and returning their score
            var prediction = engine.Predict(
                new ModelInput()
                {
                    ProdIDA = 344,
                    ProdIDB = 63
                });
            Console.WriteLine($"  Here is the prediction score of products 344 and 63 combined: {prediction.Score}");
            Console.WriteLine();

            //Providing the top 5 recommendations
            Console.WriteLine("Here are the recommendations for product 41");
            var reccs = (from m in Enumerable.Range(1, 150)
                         let prod = engine.Predict(
                             new ModelInput()
                             {
                                 ProdIDA =41,
                                 ProdIDB = (uint)m
                             })
                         orderby prod.Score descending
                         select(ProdIDA:m, Score:prod.Score)).Take(5);
            foreach (var t in reccs)
                Console.WriteLine($"Score:{t.Score}\tProduct:{t.ProdIDA}");

            //saving the built ML Model
            Console.WriteLine("Saving the model...");
            context.Model.Save(model, data.Schema, "../../../MLModels/MLModel.zip");
            Console.ReadLine();
        }
    }
}
