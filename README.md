# Docker Hello World
The Docker image based on [tutum/hello-world](https://hub.docker.com/r/tutum/hello-world/) concept. This is a very basic *Hello World* image that we use to test deployments.

## Usage
To create the image [dariuszporowski/hello-world](https://hub.docker.com/r/dariuszporowski/hello-world/), execute the following command on the src folder:
```bash
docker build -t dariuszporowski/hello-world .
```

You can now push your new image to the registry:
```bash
docker push dariuszporowski/hello-world
```

## Running your Hello World docker image
Start your image:
```bash
docker run -it --rm -p 8080:80 dariuszporowski/hello-world
```

Browse to [http://localhost:8080](http://localhost:8080) to view the web page with container hostname served by hello-world app in the running container. You should see a page similar to the following:

![hello-world](https://raw.githubusercontent.com/DariuszPorowski/docker-hello-world/master/img/docker-hello-world.png)