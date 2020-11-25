# SQL To Linq

## _context为数据库上下文

### Select

    1、   _context.databaseTable.Where(item=>item.id>0);
    2、   var items=from s in _context.databaseTable
                    where s.id>0
                    select s;

### Delete

### Update

### Insert
