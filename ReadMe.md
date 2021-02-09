1. Unzip the repository
  2. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Next, within the `\Hahn.ApplicationProcess.December2020.WebApp\ClientApp` directory, launch the front end by running:
     ```
     npm start
     ```
  5. Once the front end has started, within the `WebUI` directory, launch the back end by running:
     ```
	 dotnet run
	 ```
  5. Launch [http://localhost:8080/](http://localhost:52468/) in your browser to view the Web UI
  
  6. Launch [http://localhost:500/api](http://localhost:52468/api) in your browser to view the API