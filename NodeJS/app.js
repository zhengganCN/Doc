var express = require("express")

var app = express()

app.get('/',function(req,res) {
    res.send("hello world nodemon again")
})

app.listen(3000,function(){
    console.log('server is running nodemon')
})
