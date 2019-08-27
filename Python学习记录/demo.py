import requests
from requests import RequestException
import re
import json
import time

class Demo:           
    def get_one_page(self,url):
        try:
            response = requests.get(url)
            if response.status_code == 200:
                return response.text
            else:
                return None
        except RequestException:
            return None


    def parse_one_page(self,html):
        pattern = re.compile('<dd>.*?board-index.*?>(\d+)</i>.*?data-src="(.*?)".*?name"><a'
                             + '.*?>(.*?)</a>.*?star">(.*?)</p>.*?releasetime">(.*?)</p>'
                             + '.*?integer">(.*?)</i>.*?fraction">(.*?)</i>.*?</dd>', re.S)
        items = re.findall(pattern, html)
        for item in items:
            yield {
                'index': item[0],
                'image': item[1],
                'title': item[2],
                'actor': item[3].strip()[3:],
                'time': item[4].strip()[5:],
                'score': item[5] + item[6]
            }
 
    def write_to_file(self,content):
        with open('result.txt', 'a', encoding='utf-8') as f:
            f.write(json.dumps(content, ensure_ascii=False) + '\n')
 
    def main(self,offset):
        url = 'http://maoyan.com/board/4?offset=' + str(offset)
        html = self.get_one_page(url)
        for item in self.parse_one_page(html):
            print(item)
            self.write_to_file(html)

            
if __name__ == '__main__':
    #nbs=NBSAreaReptile()
    #html= nbs.get_html('http://www.stats.gov.cn/tjsj/tjbz/tjyqhdmhcxhfdm/2018/index.html')
    #nbs.analysis_html(html)
    demo=Demo()
    for i in range(10):
        demo.get_one_page
        demo.main(offset=i * 10)
        time.sleep(1)

