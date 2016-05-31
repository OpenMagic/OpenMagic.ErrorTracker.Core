const del = require('del');
const directory = './artifacts'; 
const mkdirp = require('mkdirp');

console.log(`Cleaning \'${directory}\'...`);        

del.sync(directory)
//console.log(`Deleted \'${directory}\'.`);        

mkdirp.sync(directory)
//console.log(`Created \'${directory}\'.`);        
        
console.log(`Successfully cleaned \'${directory}\'.`);        
