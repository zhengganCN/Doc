axios
    .post("/QRCoder/CreateQRCode", {}, {
        responseType: "arraybuffer" //返回数据类型为二进制数据
    })
    .then(result => {
        let blob = new Blob([result.data], {
            type: "image/png"
        }); //实例化blob对象
        let url = URL.createObjectURL(blob); //创建url
        let aLink = document.createElement("a");
        let evt = document.createEvent("HTMLEvents");
        evt.initEvent("click", true, true);
        aLink.download = "qrcode";//下载文件名
        aLink.href = url;
        aLink.click();
        URL.revokeObjectURL(blob);
    })
    .catch(err => {});