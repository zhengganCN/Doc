# Zipkin

## 使用docker安装zipkin

    docker run -p 9411:9411 -d openzipkin/zipkin

## 在konga中启用全局的zipkin

    为http endpoint 添加值：http://dostudy.top:9411/api/v2/spans
