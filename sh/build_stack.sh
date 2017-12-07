#!/bin/bash

# Kill and remove the docker container
docker rm -f stack_refarch_api
docker rm -f stack_refarch_ods

# Remove the docker images
docker rmi walterpinson/reference-architecture-api:stackhouse --force

# Run the Stack
docker-compose up --remove-orphans