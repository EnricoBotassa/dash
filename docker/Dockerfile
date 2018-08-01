FROM debian:stretch
LABEL maintainer="Zalgocoin Developers <dev@zalgocoin.org>"
LABEL description="Dockerised ZalgocoinCore, built from Travis"

RUN apt-get update && apt-get -y upgrade && apt-get clean && rm -fr /var/cache/apt/*

COPY bin/* /usr/bin/
