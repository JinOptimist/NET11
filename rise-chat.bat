cd GamerShop/ChatApi

docker build . --rm -t chat_api/server:latest

docker run -e ASPNETCORE_URLS=http://+:80 -p 8081:80 --name chat --network net11 chat_api/server:latest