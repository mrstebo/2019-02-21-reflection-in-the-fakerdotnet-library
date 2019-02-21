#!/bin/bash

docker run -it --rm -v $PWD:/repo -p 9000:9000 gitpitch/desktop:pro