FROM node:12.14.0 AS build-env
WORKDIR /app
# Copy everything else and build
COPY . ./
WORKDIR /app
ENV NODE_OPTIONS="--max-old-space-size=2048"
RUN npm install -g @angular/cli@9.0.3 && npm install && npm run build

# Build runtime image
FROM node:12.14.0
WORKDIR /app
ENV NODE_OPTIONS="--max-old-space-size=2048"
RUN npm i angular-http-server -g
COPY --from=build-env /app/out .
ENTRYPOINT ["angular-http-server"]
