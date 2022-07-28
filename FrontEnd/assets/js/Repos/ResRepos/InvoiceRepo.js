window.onload = function () {
   
      FetchStoresData();
      FetchCustomersData();
      FetchUnitsData();
     
  };
var itemsList ;

  function FetchUnitsData() {
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
      if (this.readyState === 4 && this.status === 200) {
        var units = JSON.parse(this.responseText);
        FillSelectbox(units,"#UnitSelectbox");
      }
    };
      request.open("Get", "https://localhost:44344/api/unit/all");
    request.send();
  }

  function FetchStoresData() {
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
      if (this.readyState === 4 && this.status === 200) {
        var units = JSON.parse(this.responseText);
        FillSelectbox(units,"#StoreSelectbox");
        FetchItemsData();
      }
    };
      request.open("Get", "https://localhost:44344/api/store/all");
    request.send();
  }

  function FetchCustomersData() {
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
      if (this.readyState === 4 && this.status === 200) {
        var customers = JSON.parse(this.responseText);
        FillSelectbox(customers,"#CustomerSelectbox");
      }
    };
      request.open("Get", "https://localhost:44344/api/customer/all");
    request.send();
  }
  

  function FetchItemsData() {
      var storeId = $("#StoreSelectbox").val();
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
      if (this.readyState === 4 && this.status === 200) {
        itemsList = JSON.parse(this.responseText);
        FillSelectbox(itemsList,"#ItemSelectbox");
        SetItemPrice();
      }
    };
      request.open("post", "https://localhost:44344/api/items/getbystore");
      request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.send(JSON.stringify(storeId));
  }

function FillSelectbox(data,selectboxTag) {
    var selectbox = $(selectboxTag);
    selectbox.empty();
  
    for (i in data) {
        selectbox.append(
        `<option value="${data[i].id}">${data[i].name}</option>`
      );
    }
    selectbox.selectpicker("refresh");
  }

  function AddNewItem(){
      if(!ValidateInput())
      return;
      var itemName= $("#ItemSelectbox :selected").text();
      var itemId= $("#ItemSelectbox").val();
      var unitName = $("#UnitSelectbox :selected").text();
      var unitId = $("#UnitSelectbox :selected").val();
      var dueDate = $("#DueDatepicker").val();
      var customerName = $("#CustomerSelectbox :selected").text();
      var customerId = $("#CustomerSelectbox :selected").val();
      var pharmDisc = $("#PharmDiscTextbox").val();
      var distDisc = $("#DistDiscTextbox").val();
      var cashDisc = $("#CashDiscTextbox").val();
      var vat = $("#VatTextbox").val();
      var quantity=$("#QuantityTextbox").val();
      var price = $("#PriceTextbox").val();
      var accDiscounts = (parseFloat(pharmDisc)+parseFloat(distDisc)+parseFloat(cashDisc))/100;
      var netBeforeDiscount= parseFloat(quantity)*parseFloat(price);
      if(accDiscounts==0)
      accDiscounts=1;
      var netAfterDiscount= netBeforeDiscount*(1-accDiscounts);
      var taxValue=netAfterDiscount*parseFloat(vat)/100;
      var totalInvoice=netAfterDiscount+taxValue;



      var tBody = $("#ItemsContainer");
     tBody.empty();
     var newRow = "<tr><td>"+itemName+"</td><td>"+unitName+"</td><td>"+quantity+"</td><td>"+price+"</td><td>"+pharmDisc+"</td><td>"+distDisc+"</td><td>"+cashDisc+"</td><td>"+netAfterDiscount+"</td><td>"+vat+"</td><td>"+taxValue+"</td><td>"+totalInvoice+"</td></tr>";
     tBody.append(newRow);
     $("#NetAfterLabel").text("Net After Disc : "+netAfterDiscount);
     $("#NetBeforeLabel").text("Net Before Disc : "+netBeforeDiscount);
     $("#TaxLabel").text("Tax : "+ taxValue);
     $("#TotalInvoiceLabel").text("Net Invoice : "+totalInvoice);



      
  }

  function Save(){
    if(!ValidateInput())
    return;
    var itemName= $("#ItemSelectbox :selected").text();
    var itemId= $("#ItemSelectbox").val();
    var unitName = $("#UnitSelectbox :selected").text();
    var unitId = $("#UnitSelectbox :selected").val();
    var dueDate = $("#DueDatepicker").val();
    var customerName = $("#CustomerSelectbox :selected").text();
    var customerId = $("#CustomerSelectbox :selected").val();
    var pharmDisc = $("#PharmDiscTextbox").val();
    var distDisc = $("#DistDiscTextbox").val();
    var cashDisc = $("#CashDiscTextbox").val();
    var vat = $("#VatTextbox").val();
    var quantity=$("#QuantityTextbox").val();
    var price = $("#PriceTextbox").val();
    var accDiscounts = (parseFloat(pharmDisc)+parseFloat(distDisc)+parseFloat(cashDisc))/100;
    var netBeforeDiscount= parseFloat(quantity)*parseFloat(price);
    if(accDiscounts==0)
    accDiscounts=1;
    var netAfterDiscount= netBeforeDiscount*(1-accDiscounts);
    var taxValue=netAfterDiscount*parseFloat(vat)/100;
    var totalInvoice=netAfterDiscount+taxValue;

    var jsonObj ={
        itemId : itemId,
        unitId:unitId,
        dueDate:dueDate,
        customerId:customerId,
        pharmDisc:pharmDisc,
        distDisc:distDisc,
        cashDiscount:cashDisc,
        vat:vat,
        vatValue:taxValue,
        quantity:quantity,
        totalInvoice:totalInvoice
    }

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
      if (this.readyState === 4 && this.status === 200) {
      alert(request.responseText);
      }
    };
      request.open("post", "https://localhost:44344/api/invoices/new");
      request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.send(JSON.stringify(jsonObj));
  }
  function ValidateInput(){
      if($("#QuantityTextbox").val()==""||$("#QuantityTextbox").val()=="0")
      {
        alert("Please Enter Quantity");
        return false; 
      }
      if($("#VatTextbox").val()=="")
      {
        alert("Please Enter Vat");
        return false; 
      }
      if($("#CashDiscTextbox").val()=="")
      {
        $("#CashDiscTextbox").val("0");
      }
      if($("#PharmDiscTextbox").val()=="")
      {
        $("#PharmDiscTextbox").val("0");
      }
      if($("#DistDiscTextbox").val()=="")
      {
        $("#DistDiscTextbox").val("0");
      }

      return true;

  }

  function SetItemPrice(){
    var t =$("#ItemSelectbox :selected").text();
    var indx = itemsList.findIndex(x=>x.name==t);
    $("#PriceTextbox").val(itemsList[indx].price);
  }
  