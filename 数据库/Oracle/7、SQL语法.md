# SQL语法

## 别名

    SELECT b.book_name
    FROM books b

## 用DISTINCT去除重复值

    SELECT DISTINCT book_name 
    FROM books

## GROUP BY

    SELECT book_name
    FROM books
    GROUP BY book_name

## LIKE

    ‘%’可以匹配一个或者多个字符
    ‘_’匹配单一字段\符
    
    SELECT 

## 处理NULL列值

    SELECT *
    FROM books
    WHERE book_name IS NULL

## ORDER BY

    SELECT *
    FROM books
    ORDER BY book_name DESC;--降序

    多列排序
    SELECT *
    FROM books
    ORDER BY book_name DESC,author ASC;--先按book_name降序，当出现相同的book_name时，按author升序排序

## 连接查询

### 内连接

    SELECT book_name,category_name
    FROM books,category
    WHERE books.cate_id=category_id

### 左连接

    SELECT book_name,category_name
    FROM books,category
    WHERE books.cate_id=category_id(+);   --ORACLE特有语法

    SELECT book_name,category_name
    FROM books,category
    LEFT JOIN category ON books.cate_id=category_id;

### 右连接

    SELECT book_name,category_name
    FROM books,category
    WHERE books.cate_id(+)=category_id;   --ORACLE特有语法

    SELECT book_name,category_name
    FROM books,category
    RIGHT JOIN books ON books.cate_id=category_id;

### 全连接

    SELECT book_name,category_name
    FROM books,category
    FULL JOIN books ON books.cate_id=category_id;

## 插入数据

    INSERT INTO books (book_name,book_author) VALUES ('SQL','LISI');

    使用子查询将books表中的数据插入到books_2中
    INSERT INTO books_2 SELECT * FROM books  --books和books_2具有相同的表结构

    INSERT INTO books_2 (book_id,book_name) SELECT book_id,book_name FROM books

## 更新数据

    UPDATE books
    SET book_name='SQL',book_author='LISU'
    WHERE book_id=1

## RETURNING子句

    ...

## 删除数据

    DELETE FROM books
    WHERE book_id=1;

    对已删除的数据回滚
    ROLLBACK
