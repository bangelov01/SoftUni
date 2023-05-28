## Task 1: Run Lightstreamer container with the following requirements:

- The image you need is lightstreamer:latest
- Your container's name should be ls-server
- Server works on port 8080, but should be accessed on localhost:80
- Container should be run in detached mode

### Solution command:
-   `docker run -d -p 80:8080 --name ls-server lightstreamer:latest`

___

## Task 2: Run Ghost container with the following requirements:

- The image you need is ghost:latest
- Your container's name should be ghost-container
- Server works on port 2368, but should be accessed on localhost:3001
- You should set NODE_ENV=development as an environment variable with the -e option
- Container should be run in detached mode

### Solution command:
-   `docker run --env NODE_ENV=development -d -p 3001:2368 --name ghost-container ghost:latest`

___

## Task 3: Run Apache HTTP Server Container with the following requirements:

- Use the latest image: httpd:latest
- Your container's name should be my-apache-app
- Server works on port 80, but should be accessed on localhost:8080
- Container should be run in detached mode
- You should create a volume – map current PowerShell (or another) directory to the container's directory
/usr/local/apache2/htdocs/

### Solution command:
-   `docker run -d -p 8080:80 --name my-apache-app -v .\apache:/usr/local/apache2/htdocs/ httpd:latest`

___

## Task 4: Run an Sqlserver container with a Docker volume:

### Solution command
-   `docker run --env ACCEPT_EULA=Y --env MSSQL_SA_PASSWORD=myStrongPassword1# -p 1433:1433 -v sqldata:/var/opt/mssql -d mcr.microsoft.com/mssql/server:latest`

___

## Task 5: Run MariaDB Client and Server in a Network with requirements:

-  MariaDB database server container, initialized with database user and password
- Another container, which will run the MariaDB command line client against the MariaDB server container,
allowing you to execute SQL statements against your database instance.

### Solution commands:
-   `docker network create mariadb_network`
-   `docker run --env MARIADB_USER=mariadbuser --env MARIADB_PASSWORD=myStrongPassword12# --env MARIADB_ROOT_PASSWORD=mySecretPassword12# --name mariadb_server --network mariadb_network -d mariadb:latest`
-   `docker run -it --name mariadb_client --network mariadb_network --rm mariadb mariadb -h mariadb_server -u mariadbuser -p`
-   `docker network inspect mariadb_network`

___


## Task 6: Taskboard_App
- In the Taskboard_App, create Dockerfile in VS
- Build and Publish the Image to Docker Hub

### Solution commands:
-   `docker build . -f ./TaskBoard.WebApp/Dockerfile -t <dockerHubUsername>/taskboard_app`
-   `docker push <dockerHubUsername>/taskboard_app`

___


## Task 7: Tracker_App
- In the Taskboard_App, build an image from a created Dockerfile
- Build and Publish the Image to Docker Hub
- Create a container from the image

### Solution commands:
-   `docker image build -t <dockerHubUsername>/tracker_app .`
-   `docker push <dockerHubUsername>/tracker_app`
-   `docker run --name tracker_app -p 8080:80 -d <dockerHubUsername>/tracker_app`

___


## Task 8: Todo_App - a React application with a NodeJS backend and a MongoDB database
- Name the three containers "frontend", "backend" and "mongo"
- Build images from the provided Dockerfiles for the frontend and backend services
- Use the latest image for MongoDB from Docker Hub
- Expose the frontend service on port 3000
- Mount the following host directories as volumes:
o For mongo service: .\data:/data/db
- Connect the frontend and backend services to the react-express network and the backend and mongo
services to the express-mongo network

### Solution commands:
-   `docker network create react_express`
-   `docker network create express_mongo`
-   `docker image build -t backend_app_img .`
-   `docker run -p 27017:27017 --name mongo -v .\data:/data/db  -d mongo:latest`
-   `docker run --name backend -d backend_app_img`
-   `docker run -p 3000:3000 --name frontend -d frontend_app_img`
-   `docker network connect express_mongo mongo`
-   `docker network connect express_mongo backend`
-   `docker network connect react_express backend`
-   `docker network connect react_express frontend`

___

## Task 9: Blue_Vs_Green_App - simple voting app
- Use the latest images for PostgeSQL and Redis from Docker Hub and use the Dockerfiles you created for the 
voting and worker app
- PostgreSQL container needs user and password for login: see how to set them in the image's 
documentation
- The voting app should be accessed on localhost:5000 and the result app – on localhost:5001
- Network traffic should be separated to two networks – frontend and backend:
    - The frontend network is for the users' traffic. Connect the voting app and the result app to it
    - The backend network is for the traffic within the app. It connects all app components
- Run the voting and result apps in the containers
- Use volumes for the voting and result apps and the db container
- Run everything with docker compose

### Solution:
-   Write Dockerfile in Blue_Vs_Green_App/worker
-   Write Dockerfile in Blue_Vs_Green_App/vote
-   `docker image build -t worker .`
-   `docker image build -t vote .`