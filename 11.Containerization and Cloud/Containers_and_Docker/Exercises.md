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
