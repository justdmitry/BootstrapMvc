cd BootstrapMvc.Core
..\.nuget\nuget.exe pack -build -Prop Configuration=Release
cd ..

cd BootstrapMvc.Bootstrap3
..\.nuget\nuget.exe pack -build -Prop Configuration=Release
cd ..

cd BootstrapMvc.Mvc5
..\.nuget\nuget.exe pack -build -Prop Configuration=Release
cd ..

cd BootstrapMvc.Bootstrap3Mvc5
..\.nuget\nuget.exe pack -build -Prop Configuration=Release
cd ..

pause
