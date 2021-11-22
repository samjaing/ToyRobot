echo Building Project...
dotnet build

if [ $? -eq 0 ]
then
	echo Running Toy Robot...
	dotnet run --project ./ToyRobot
fi
