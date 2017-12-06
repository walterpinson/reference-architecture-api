#!/bin/bash

# Kill and remove the docker container
docker rm -f refarch_api

# Run the docker image with all of the necessary overrides
docker run  -itd -p 5001:80 \
-e ASPNETCORE_ENVIRONMENT \
-e NoteTaker__NotificationService__SendGrid__ApiKey \
-e ConnectionStrings__NoteTakingService \
--name refarch_api walterpinson/reference-architecture-api