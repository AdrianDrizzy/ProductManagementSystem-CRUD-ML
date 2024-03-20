# Product-Management-App
CRUD Function + ML Component 
https://showcase.sit.uct.ac.za/event/showcase-2021/cog3nt-product-management-and-clustering-system
The Cog3nt Product Management and Clustering System is a web application that offers a comprehensive suite of product management and clustering functionalities using the latest machine learning technologies to help businesses optimize their product offerings and boost their sales. The platform is built using an n-tier architecture, which ensures that it is scalable and adaptable for businesses of all sizes. The platform offers end-to-end flow between the web application and related machine learning applications through the use of an application programming interface (API).

The platform's key features include product management capabilities that allow users to easily create, read, update, and delete existing products in the application's database through a simple and intuitive interface, making it easy for businesses to keep track of their product inventory and make real-time updates to their offerings. The product clustering functionality utilizes a powerful machine learning algorithm that analyzes past transaction history to generate personalized recommendations of products for sale, helping businesses increase their sales and revenue.

The platform is designed to be user-friendly and intuitive, with a clean and modern interface that makes it easy for users to navigate and perform tasks. Users can upload documentation of current records to populate the database and generate new recommendations, which helps to keep the platform up-to-date and relevant.

The use of Microsoft's ASP.NET Core framework for its build and Microsoft's ML.Net libraries & classes to generate a 'recommender system' algorithm ensures that the application is reliable, robust, and secure. Businesses can easily integrate the platform with other tools and technologies, such as data analytics platforms or marketing 
automation software, to streamline their operations and improve their bottom line.

Product Management
Welcome to the Product Management system! This project is built with C# and ASP.NET, designed to perform CRUD (Create, Read, Update, Delete) operations on products efficiently. Additionally, it leverages ML.NET to provide intelligent product recommendations based on users' purchasing histories, enhancing the shopping experience.

Features
CRUD Operations: Manage your product listings with full create, read, update, and delete capabilities.
Product Recommendations: Utilizes ML.NET to offer personalized product recommendations based on historical purchase data.
Prerequisites
Before you begin, ensure you have the following installed:

.NET 5.0 SDK or later
Visual Studio 2019 or later with the ASP.NET and web development workload
SQL Server (Express or higher) for database operations
Getting Started
To get a local copy up and running, follow these simple steps.

Cloning the Repository
Open your command line or terminal.

Navigate to the directory where you want to clone the project.

Clone the repository using:

bash
Copy code
git clone https://github.com/yourusername/ProductManagement.git
Navigate into the project directory:

bash
Copy code
cd ProductManagement
Downloading the ZIP
Go to the repository on GitHub: https://github.com/yourusername/ProductManagement
Click the Code button and then click Download ZIP.
Extract the ZIP file to your desired location.
Open the extracted folder.
Setting Up the Database
Open SQL Server Management Studio (SSMS) and connect to your database server.
Execute the SQL script located in Database/Script.sql to create and populate the database.
Running the Application with Visual Studio
Open Visual Studio.
Select Open a project or solution.
Navigate to the directory where you cloned or extracted the project and select the solution file (ProductManagement.sln).
Wait for Visual Studio to restore any missing NuGet packages.
Ensure the web project is set as the startup project.
Press F5 or click Start to run the application.
Using the Application
Once the application is running:

Navigate to the products page to view, add, edit, or delete products.
Use the recommendations feature to see product suggestions based on purchase history (make sure to have some purchasing history data for the recommendations to work).
Contributing
Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are greatly appreciated.

Please refer to the CONTRIBUTING.md for more information.

License
Distributed under the MIT License. See LICENSE for more information.
