This project was developed at the college, integrated with three subjects (Project Factory III, Software Development Platform, and Front-End Technologies), where we applied knowledge acquired during the semester.

### Developed by 
##### Felipe Leite
##### Nicole Zion

## Recommended IDE

[VSCode](https://code.visualstudio.com/) and
[VisualStudio](https://code.visualstudio.com)

# Discount Wheel

![image](https://github.com/user-attachments/assets/453a0693-0a6f-4c9b-987d-31988c332627)


In order to solve the problem of cart abandonment in an e-commerce platform, we approached several solutions in this project, with the main one being a Wheel that randomly selects discounts on the total cart value. It was developed using Vue.js, C#, and MySQL.

### Prerequisites
Vue.js 3.4, NPM 10.5.0, Node.js 21.7.2, MySQL 8.0.37, .NET Core SDK 8.0.300, Axios 1.7.2. 
These or higher versions are required.

## Installation Instructions

### Front-end
Dowload and install [Noje.js](https://nodejs.org/en/download/package-manager/current) 21.7.2 or higher
Follow instructions on official website.

#### In the project folder, run:
```sh
npm install
```
```sh
npm run dev
```

### Back-end

1. *Configure the MySQL Database:*
   - Create a database in MySQL (version 8.0.37 or higher).
   - Configure the `appsettings.json` file with the database access credentials.

2. *Install necessary libraries:*
    ```bash
    dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.2
    ```
    ```bash
    dotnet add package Pomelo.EntityFrameworkCore.MySql.Design --version 1.1.2
    ```

    ```bash
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.8
    ```

3. *Run the database migrations:*  
   Execute the following command to apply the migrations and create the necessary tables in the MySQL database:
   ```sh
   dotnet ef database update
   ```
4. *Install the Swashbuckle package:*
```sh
dotnet add package Swashbuckle.AspNetCore
```
5. *Install tool required*
```
dotnet tool install --global dotnet-ef
```

5. *Running the Back-end:*  
   To start the API, use the command:
   ```sh
   dotnet ef dbcontext scaffold "Server={SeuServer};User Id=root;Password={SuaSenha};Database={SeuBD}" "Pomelo.EntityFrameworkCore.MySql" -c {SeuDominio}DbContext
   ```
   ```sh
   dotnet ef database update
   ```

   This will run the server on localhost at the configured port.

### Back-end Dependencies:
- .NET Core SDK 8.0.300
- MySQL 8.0.37 or higher

### Usage Instructions
1. Open localhost:5173
2. Use the site

---
