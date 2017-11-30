#!/bin/bash

# Set the configuration environment variables
source ./sh/dev.env.sh

# Build and publish the app
source ./sh/build_app.sh

# Build the docker image
source ./sh/build_image.sh

# Kill and remove the docker container
# Run the docker image with all of the necessary overrides
source ./sh/build_container.sh