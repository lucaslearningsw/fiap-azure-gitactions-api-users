http://localhost:5008/scalar/v1#tag/apijogos/GET/games

Testing local http://localhost:{port}/scalar/v1 

docker build -t apijogos .
docker run -p 8080:8080 apijogos


===============================================================================================================
API JOGOS


1 - criar azure acr 

2 - az login 

3 - az acr login --name acrfiapnet "nome do seu acr"


4 - docker build -t apijogos . -  docker tag apijogos acrfiapnet.azurecr.io/apijogos:v1

5 - docker push acrfiapnet.azurecr.io/apijogos:v1

6 - criar azure service plan (webapp) 

7 - https://apijogos-f4dngmc5d8b0dzce.canadacentral-01.azurewebsites.net/scalar/v1 - testing 


curl https://apijogos-f4dngmc5d8b0dzce.canadacentral-01.azurewebsites.net/games


curl -X POST https://apijogos-f4dngmc5d8b0dzce.canadacentral-01.azurewebsites.net/games \
  -H "Content-Type: application/json" \
  -d '{"id": 0, "name": "Elden Ring"}'


curl -X POST https://apijogos-f4dngmc5d8b0dzce.canadacentral-01.azurewebsites.net/games \
  -H "Content-Type: application/json" \
  -d '{"id": 0, "name": "GTA"}'

===============================================================================================================


API USERS


1 - docker build -t apiusers . -  docker tag apiusers acrfiapnet.azurecr.io/apiusers:v1

2 -  docker push acrfiapnet.azurecr.io/apiusers:v1

docker run -p 8080:8080 apiusers



https://apiusers-c3gtcpgse2bfhegk.canadacentral-01.azurewebsites.net/


curl https://apiusers-c3gtcpgse2bfhegk.canadacentral-01.azurewebsites.net/users


-- Name that already exist
curl -X POST https://apiusers-c3gtcpgse2bfhegk.canadacentral-01.azurewebsites.net/users \
  -H "Content-Type: application/json" \
  -d '{"id": 0, "name": "Marcelo Lima"}'
  
  
-- Name that does not  exist
curl -X POST https://apiusers-c3gtcpgse2bfhegk.canadacentral-01.azurewebsites.net//users \
  -H "Content-Type: application/json" \
  -d '{"id": 0, "name": "Lima"}'
  
===============================================================================================================


APIM 


1 - Create APIM at azure 

2 - take openai.json from scalar 

api jogos ex.

https://apijogos-f4dngmc5d8b0dzce.canadacentral-01.azurewebsites.net/openapi/v1.json 


api users ex.

https://apiusers-c3gtcpgse2bfhegk.canadacentral-01.azurewebsites.net/openapi/v1.json


To test is necessary pass Ocp-Apim-Subscription-Key in Headers 




curl "https://<your-apim-name>.azure-api.net/games/games" \
  -H "Ocp-Apim-Subscription-Key: <your-primary-key>"


curl -X POST "https://<your-apim-name>.azure-api.net/games/games" \
  -H "Ocp-Apim-Subscription-Key: <your-primary-key>" \
  -H "Content-Type: application/json" \
  -d '{"id": 0, "name": "GTA 6"}'



  curl "https://apim-lab-fiap-nett.azure-api.net/apiusers/users" \
  -H "Ocp-Apim-Subscription-Key: 940359ae8f434244b0d3ee8d957102da"
