const tblBlog = 'Tb_Blog';
run();
function run(){
    //createBlog('title', 'author', 'content');
    //readBlog();
    //editBlog('0320a271-5cc6-42a9-9f62-9a134139256b');
    //editBlog('0');
    //const id = prompt("Enter Id");
    //deleteBlog(id);

    const id = prompt("Enter Id");
    const title = prompt("Enter Title");    
    const author = prompt("Enter Author");
    const content = prompt("Enter Content");
    updateBlog(id,title,author,content);
}
   
function readBlog(){
     let lstBlog = getBlog();
     for(let i = 0 ; i < lstBlog.length ; i++){
      const item = lstBlog[i];
      console.log(item.Title);
      console.log(item.Author);
      console.log(item.Content);
     }
}

function createBlog(title, author, content){
 
   let lstBlog = getBlog();
     const blog ={
      Id:uuidv4(),
      Title: title,
      Author: author,
      Content: content
     }
     lstBlog.push(blog);
      setLocalStorage(lstBlog);
}

function editBlog(id){
    let lstBlog = getBlog();
    let lst = lstBlog.filter(x => x.Id== id); //array
    if(lst.length == 0 ){
      console.log("No data found.")
      return;
    }

    let item = lst[0];
    console.log(item);
}

function updateBlog(id , title, author , content){
   let lstBlog = getBlog();
   let lst = lstBlog.filter(x => x.Id== id); //array
   if(lst.length == 0 ){
     console.log("No data found.")
     return;
   }
   let index = lstBlog.findIndex( x=> x.Id == id);
   lstBlog[index] = {
      Id:id,
      Title: title,
      Author: author,
      Content: content
   }

   setLocalStorage(lstBlog);
}

function deleteBlog(id){

   let lstBlog = getBlog();
    let lst = lstBlog.filter(x => x.Id== id); //array
    if(lst.length == 0 ){
      console.log("No data found.")
      return;
    }
     lst = lstBlog.filter(x => x.Id !== id);
     setLocalStorage(lst);
}

function uuidv4() {
   return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
     (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
   );
 }

 function getBlog(){
   let lstBlog = [];
   let blogsStr = localStorage.getItem(tblBlog);
   if(blogsStr != null){
      lstBlog = JSON.parse(blogsStr);
   }
   return lstBlog;
 }

 function setLocalStorage(blogs){
   let jsonStr = JSON.stringify(blogs);
   localStorage.setItem(tblBlog,jsonStr);
 }