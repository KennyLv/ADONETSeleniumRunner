
var len = document.getElementsByName("count").length;
$(document).ready(
function(){

//get dynamic id for relate element
	for(var i=0;i<len;i++)
	{
	     var countObj=document.getElementsByName("count")[i];
		countObj.value = i;
		var legendObj=countObj.parentNode;		
		//get id for <U> 
		var UObj= legendObj.parentNode;
		UObj.id="head"+i;
		//get  title div
		var titleDivObj=UObj.parentNode;
		//get fieldset
		var fieldsetObj=titleDivObj.parentNode;
		//get body Div
		var bodyDivObj=fieldsetObj.childNodes[1];//Only for firefox
		bodyDivObj.id="body"+i;
		//get table Div
		var tableObj=bodyDivObj.firstChild;
		tableObj.id="table"+i;
    }
    
    if(document.getElementById("MyPannel_Role1"))
    {  
          setupPanes("MyPannel_Role1", "defaultTab_Role1","allFrames_Role1");	
    } 
    if(document.getElementById("MyPannel_Role2"))
   {    
	    setupPanes("MyPannel_Role2", "defaultTab_Role2","allFrames_Role2");	
   }  
   
    if(document.getElementById("MyPannel_Role3"))
   {    
	    setupPanes("MyPannel_Role3", "defaultTab_Role3","allFrames_Role3");	
   }  
    if(document.getElementById("MyPannel_Role4"))
   {    
	    setupPanes("MyPannel_Role4", "defaultTab_Role4","allFrames_Role4");	
   }  
    if(document.getElementById("MyPannel_Role5"))
   {    
	    setupPanes("MyPannel_Role5", "defaultTab_Role5","allFrames_Role5");	  
   }  
    
	for(var i=0;i<len;i++)
	{	
		$("#head"+i).toggle(
		function(){
			var countObj = event.srcElement.childNodes[0];
			//alert(countObj.value);
			 $("#body"+countObj.value).slideDown('slow');
		},function(){
			var countObj = event.srcElement.childNodes[0];
			 $("#body"+countObj.value).slideUp('slow');
		})
		
		//combin the column of the table
		uniteTable("table"+i.toString(),1);
	}
	
}); 

/*
'tb' is the destination table
'col' is the destination td
*/
	function   uniteTable(tb,col)
	{
	        var table=document.getElementById(tb);
			var   i=0;
			var   j=0;
			var   rowCount=table.rows.length;			
			var   colCount=table.rows[0].cells.length; 
			var   obj1=null;
			var   obj2=null;
			//
			for   (i=0;i<rowCount;i++)
			{
	                for(j=0;j<colCount;j++)
	                {
		                    table.rows[i].cells[j].id=tb.toString()+"_"   +   i.toString()   +   "_"   +   j.toString();
	                }
		     }
                                				  
             obj1=document.getElementById(tb.toString()+"_0_"+col.toString());
		    for   (j=1;j<rowCount;j++)
		    {	
		            obj2=document.getElementById(tb.toString()+"_"+j.toString()+"_"+col.toString());
		            if   (obj1.innerText   ==   obj2.innerText)//innerHTML
		            {
		                  obj1.rowSpan++;   
		                 obj2.parentNode.removeChild(obj2);   
		            }
	    	        else
		            {
		                  //change orgain text
		                obj1=document.getElementById(tb.toString()+"_"+j.toString()+"_"+col.toString());   
		            }
            }   
    }
  
    
var panes = new Array();
function setupPanes(containerId, defaultTabId,framesId)
 {
        panes[containerId] = new Array();
        var maxHeight = 0; 
        var maxWidth = 0;
        var container = document.getElementById(containerId);//MyPannel_Role1
        var paneContainer = document.getElementById(framesId);//allFrames_Role1       
        var paneList = paneContainer.childNodes;//Participant_PPLAdmin,Invoice_PPLAdmin¡­¡­
       var titletableContainer=container.childNodes[0];//MyTitle_Role1 
       
       var allcasesforthisrole=0;

        for (var i=0; i < paneList.length; i++ ) 
        {
                var pane = paneList[i];//Participant_PPLAdmin
                if (pane.nodeType != 1) continue;
                //if (pane.offsetHeight > maxHeight) maxHeight = pane.offsetHeight;
                if (pane.offsetWidth > maxWidth ) maxWidth = pane.offsetWidth;
                panes[containerId][pane.id] = pane;
                pane.style.display = "none";
                
                
                /*static the result for every module*/
                var totalcase=0;
                var succeedcase=0;
                //number of table rows
                for (var casenum=0; casenum <pane.childNodes.length;casenum++)
                {
                    var caseTableObj=pane.childNodes[casenum].childNodes[1].childNodes[0];
                    totalcase+=  caseTableObj.rows.length-1;
                   allcasesforthisrole+=  totalcase;
                    for(var n=1;n<caseTableObj.rows.length;n++)//begin at the second <tr/>
                    {
                 
                         if(caseTableObj.rows[n].cells[4].innerText=="Succeed")
                         {
                             succeedcase+=1;
                         }
                    }
                    casenum++;//trere are another childNodes that we don't need!
                }
               
                //change the html to show out the result
                 titletableContainer.rows[0].cells[i].childNodes[0].innerHTML +="<br/><font style='color:red'>"+totalcase+"/"+succeedcase+"</font>";
        }
        if(allcasesforthisrole==0)
       {
            container.parentNode.style.display="none";
       } 
        
       if( maxHeight<20)
       {
            maxHeight=20;
       }
        paneContainer.style.height = maxHeight + "px";
        paneContainer.style.width = maxWidth + "px";        
        document.getElementById(defaultTabId).onclick();
}

function showPane(paneId,titleid,activeTab)
 {
          // make tab active class
          // hide other panes (siblings)
          // make pane visible
          activeTab.blur();
           
         var menus= document.getElementById(titleid) ;
         var menuList =menus.getElementsByTagName("div");
         for (var i=0; i<menuList.length; i++ ) 
         {
                    var tab = menuList[i];
                    tab.style.background = "#FFFFFF ";  
                    tab.style.height="45px";
         } 
         activeTab.style.background = "#CCCCCC";   

        

         for (var con in panes) 
         {
                    //activeTab.className = ".div_clicked";                  
                    //activeTab.style.background = "#FF0000"; 

                    if (panes[con][paneId] != null) 
                    {
                          // tab and pane are members of this container
                           var pane = document.getElementById(paneId);
                           pane.style.display = "block";
                            
                           var container = document.getElementById(con);
                           var tabs = container.getElementsByTagName("tr")[0];
                           var tabList = tabs.getElementsByTagName("a")
                           for (var i=0; i<tabList.length; i++ ) 
                            {
                                    var tab = tabList[i];
                                    if (tab != activeTab) tab.className = "tab-disabled";
                           }
                           for (var i in panes[con])
                           {
                                    var pane = panes[con][i];
                                    if (pane == undefined) continue;
                                    if (pane.id == paneId) continue;
                                    pane.style.display = "none"
                           }
                   }
         }
            return false; 
}
