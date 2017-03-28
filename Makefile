run-with-db: database-prep run-clean

run-clean: cleanup restore build run 

all : cleanup restore build

cleanup:
	dotnet clean src/Squadron.TestApplication/

restore:
	dotnet restore src/Squadron.TestApplication/

build:
	dotnet build src/Squadron.TestApplication/

run:
	dotnet run -p src/Squadron.TestApplication/Squadron.TestApplication.csproj

database-cleanup:
	docker stop squadron-test-application
	docker rm squadron-test-application

database-prep:
	docker pull kiasaki/alpine-postgres
	docker run --name squadron-test-application -e POSTGRES_PASSWORD=mysecretpassword -d kiasaki/alpine-postgres