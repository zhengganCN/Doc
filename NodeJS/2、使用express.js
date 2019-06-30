var express = require("express")

var app = express()

app.get('/',function(req,res) {
    res.send("hello world")
})

app.listen(3000,function(){
    console.log('server is running')
})


//启动
//1.   node app.js
//或者
//2.   nodemon app.js