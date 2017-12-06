#!/bin/bash

# Set the configuration environment variables
source ./sh/dev.env.sh

# Build and publish the app
source ./sh/build_app.sh

# Kill and remove the stack's docker containers
# Run the stack
source ./sh/build_stack.sh