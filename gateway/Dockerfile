# syntax=docker/dockerfile:1.4

FROM node:lts

WORKDIR /usr/src/app

COPY package.json /usr/src/app
COPY package-lock.json /usr/src/app

RUN npm ci

COPY . /usr/src/app

EXPOSE 5000

CMD ["npm", "start"]