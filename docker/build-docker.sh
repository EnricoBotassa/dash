#!/usr/bin/env bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
cd $DIR/..

DOCKER_IMAGE=${DOCKER_IMAGE:-enricobotassa/zalgocoind-develop}
DOCKER_TAG=${DOCKER_TAG:-latest}

BUILD_DIR=${BUILD_DIR:-.}

rm docker/bin/*
mkdir docker/bin
cp $BUILD_DIR/src/zalgocoind docker/bin/
cp $BUILD_DIR/src/zalgocoin-cli docker/bin/
cp $BUILD_DIR/src/zalgocoin-tx docker/bin/
strip docker/bin/zalgocoind
strip docker/bin/zalgocoin-cli
strip docker/bin/zalgocoin-tx

docker build --pull -t $DOCKER_IMAGE:$DOCKER_TAG -f docker/Dockerfile docker
