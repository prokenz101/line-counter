# line-counter
 A simple C# program to count the number of lines in your code project.

**This is the Linux version, if you're using Windows then please use [this](https://github.com/prokenz101/line-counter).**

<br />

## Install
### **This will require the .NET 6 SDK.**

Run the following commands:

```bash
git clone https://github.com/prokenz101/line-counter/tree/linux-x64
cd line-counter
dotnet publish -c Release --self-contained false
cd bin/Release/net6.0/linux-x64/publish
xdg-open ./
```

Now, copy the executable called `line-counter` and paste it into any code project that you have.

<br />

## Use
Once the `line-counter` executable file is in your code project, you may execute it in terminal.

You must specify the file extensions for it to know what files to count lines for (like .py or .cs or .js)

Example:

```bash
./line-counter .py
```

The above command will make the program calculate the number of lines in every python file (in the current directory and all its children).

<br />

### Bugs?
Too bad.

Code this program yourself in whatever language you want if you don't want bugs.
