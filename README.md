 ## Общая структура


 #### (interface) Model
 ###### fields:
 * Начальные данные
 * Список (массив, множество, ...) статических элементов;
 * Список генераторов
 ###### methods:
 * begin
 * start
 * stop
 * end
 
 
 #### (interface) StaticElements
 ###### fields:
 * -
 ###### methods:
 * doTake(T transact)
 * doDo()
 * doGive()
 
 
 #### (interface) Transact
 ###### fields:
 * ...
 ###### methods:
 * toChange()
 
 
 #### Generator
 ###### fields:
 * 
 ###### methods:
 * 
