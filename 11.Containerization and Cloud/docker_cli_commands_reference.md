## Image commands

___

-   `docker pull <image name>` - pulls image from hub
-   `docker images` - list of all images
-   `docker rmi <image_id>/<image_name>` - deletes image

## Container commands

___

-   [`docker run <image_id>`](https://docs.docker.com/engine/reference/commandline/run/) - creates and runs a new container from the image
-   `docker run -d <image_id>` - creates and runs container in --detach mode
-   `docker run -p 5000:80 -d --name <name> <image_id>` - runs container with port, detached and with given name
-   `docker run -it -p 8080:8080 -v ${PWD}:/app -w /app <image_id>/<image_name> <command e.g npm run dev>` - runs a container with interactive shell, port 8080,  binding our work directory to a working directory inside the container, starting with a given command
    -   `it` - interactive shell in container
    -   `-v` - bind mount a volume
    -   `-w` - working directory in the container
    -   `--env` - describe environemnt variable
    -   `--rm` - removes the container after it is stopped
-   [`docker ps`](https://docs.docker.com/engine/reference/commandline/ps/) - list of all running containers
-   `docker ps -a` - list of all containers
-   `docker stop <container_id>/<container_name> (can be first 2 symbols)` - stops container
-   `docker start <container_id>/<container_name>` - starts container
-   `docker rm <container_id>/<container_name>` - deletes non-running conatiner
-   `docker rm -f <container_id>/<container_name>` - deletes running conatiner
-   `docker logs <container_id>/<container_name>` - shows logs of container
-   `docker exec -it <bash(bash) | /app/bash(powershell)>` - runs the container's bash shell
-   `docker network ls` - lists all networks
-   `docker network inspect <network_id>` - info on which containers are attached to network
-   `docker network rm [network1, network2...]` - deletes single or multiple networks

## Dockerfile - in app/startup proj directory

___


-   `docker image build -t <image_name> .` builds an image of the Dockerfile located in the current dir.
-   Execute multiple commands in a single command line, used mostly for single stage build. e.g.
```
    RUN apk update \
        && apk add curl \
        && apk add lynx \
        && rm -rf /var/cache/apk/* -- deletes cache for image size optimization
```

## Docker compose

___


-   [`docker compose up -d`](https://docs.docker.com/engine/reference/commandline/compose_up/) - create and start containers in silent mode
-   `docker compose up --build` - builds images before starting containers
-   `docker compose build` - builds services
-   `docker compose ps` - list of services
-   `docker compose down` - stops containers and removes everything started by `up`
-   `docker-compose down --rmi all --volumes` - remove all images, volumes, containers etc.
-   `docker compose config` - shows the configuration of current compose setup