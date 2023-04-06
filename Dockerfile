FROM  node:latest as stage1
WORKDIR /cnu
COPY . .

RUN NODE_ENV=development npm i

RUN npm install

RUN npm run build

FROM nginx:alpine
COPY --from=stage1 /cnu/dist/angular-project /usr/share/nginx/html
EXPOSE 443