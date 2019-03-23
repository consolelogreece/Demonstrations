var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

app.get('/', function(req, res){
    res.sendFile(__dirname + '/index.html');
});

io.on('connection', function(socket){
    socket.on('disconnect', () => console.log("a user disconnected"))
    socket.on("message", (x) => {
        io.emit("message", {
            message: x,
            timestamp: Date.now()
        })
    });
    console.log('a user connected');
});

http.listen(3030, function(){
  console.log('listening on port 3030');
});