#!/bin/bash

# Kill and remove the docker container
docker rm -f stack_refarch_api
docker rm -f stack_refarch_ods

# Run the Stack
docker-compose up --remove-orphans