cd GamerShop/RoomApi

docker build . --rm -t room_api/server:latest

docker run -e ASPNETCORE_URLS=http://+:80 -p 8082:80 --name room --network net11 room_api/server:latest