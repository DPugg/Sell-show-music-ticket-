
//====================================hien thong tin thanh vien====================================
//====================================hien thong tin thanh vien====================================
/*
function reply_click(clicked_id) {

	var getAPI = 'https://localhost:44315/api/thanhvien/public/all';
	function start() {
		getMembers(renderMembers);
	}


	start();
	function getMembers(callback) {
		fetch(getAPI)
			.then(function(response) {
				return response.json();
			})
			.then(callback);
	}

	function renderMembers(members) {
		var memberInfo = document.querySelector('#name');

		var htmls = members.map(function(member) {

			if (member.ngheDanh == clicked_id) {


				document.getElementById("profile_member_img").src = `data:image/png;base64, ${member.avatar}`;

				return `
       <div class="name" id="name" >Nghệ danh: ${member.ngheDanh}</div> 
      `;
			}
		});

		memberInfo.innerHTML = htmls.join('');
	}
}
*/



 //====================================hien ds thanh vien====================================
//====================================hien ds thanh vien====================================
 //====================================hien ds thanh vien====================================
//====================================hien ds thanh vien====================================
 //====================================hien ds thanh vien====================================
//====================================hien ds thanh vien====================================
 //====================================hien ds thanh vien====================================
//====================================hien ds thanh vien====================================

//https://localhost:44315/api/thanhvien/public/all


	var getAPIDsTv = 'https://localhost:44315/api/thanhvien/public/all';
	function startDsTv() {
		getMembersTv(renderMembersTv);
	}

	startDsTv();
	function getMembersTv(callback) {
		fetch(getAPIDsTv)
			.then(function(response) {
				return response.json();
			})
			.then(callback);
	}
	
	//====================================hien thong tin thanh vien====================================
//====================================hien thong tin thanh vien====================================
//https://localhost:44315/api/thanhvien/public/by-id?idThanhVien=1
function memberInfor(clicked_id) {
	console.log(clicked_id);
	var url = new URL('https://localhost:44315/api/thanhvien/public/by-id')

    var params = {idThanhVien: clicked_id} 
    

    url.search = new URLSearchParams(params).toString();

	console.log(url);
    fetch(url)
    .then(response => response.json())
      .then(member => {
		//	var memberI = document.querySelector('#profile_info');
			
			console.log(member);
			document.getElementById("profile_member_imgg").src = `data:image/png;base64, ${member.avatars}`;
			document.getElementById('name').innerHTML="Nghệ danh: "+member.ngheDanh;
			document.getElementById('fullName').innerHTML="Tên khai sinh: "+member.tenKhaiSinh;
			document.getElementById('bd').innerHTML="Ngày sinh:" +member.ngaySinh;
			document.getElementById('nationality').innerHTML="Quốc tịch:" +member.quocTich;
			document.getElementById('DebutDate').innerHTML="Ngày Debut:" +member.debutDate;
			document.getElementById('life').innerHTML="Tiểu sử: "+member.tieuSu;
			document.getElementById('instagram').innerHTML=member.instagram;
			document.getElementById('twitter').innerHTML=member.twitter;
			})
		

      .catch((error) => {
        console.error('Error:', error);
      });
	
	
}

	function renderMembersTv(membersTv) {
		var memberInfoTv = document.querySelector('#member-list');

		var htmlsTv = membersTv.map(function(memberTv) {
			

				return `
      			<div class="member-item" id=${memberTv.idThanhVien} onClick="memberInfor(this.id)">

					<img class="member-img" src="data:image/png;base64,${memberTv.avatar}"
						alt="member imgage">
					<div class="member-name">
						${memberTv.ngheDanh}
						
					</div>
				</div>
      		`;
			
		});
		memberInfoTv.innerHTML = htmlsTv.join('');
//========================================use modal====================================
//========================================use modal====================================
//========================================use modal====================================

		
		
		
         const buyBtns = document.querySelectorAll('.buy-ticket')
         const model = document.querySelector('.model')
         
       	 const show_Members_infor = document.querySelectorAll('.member-item')
         const model_member = document.querySelector('.model_member_infor')
         
         const modal_bill = document.querySelector('.modal_bill')
         
         const modelClose = document.querySelector('.js-model-close')
         const closeTest = document.querySelector('.js-close-memberInfo')
         const modalClose = document.querySelector('.js-close-Bill')

         //ham hien phan mua ve (them class openModel vao the model)
         function showBuyTicket(){
             model.classList.add('openModel')     
           //  IdShow = documemt.getElementById('this.id').name;
             //console.log(IdShow);
         }
         function showMember_infor(){
             model_member.classList.add('openModel')
             
         }
         function showBill(){
        	 modal_bill.classList.add('openModel')
         }
         
         //ham an pham mua ve (xoa class openModel di)
         function hideBuyTicket(){
             model.classList.remove('openModel')
         }

         function hideMember_infor(){
             model_member.classList.remove('openModel')
         }

         function hide_bill(){
        	 modal_bill.classList.remove('openModel')
         }
         
         //lap qua tung the button va lang nghe su kien click
  
         
         for(const buyBtn of buyBtns){
             buyBtn.addEventListener('click',showBuyTicket	)	 
             
         }
         for(const showInfor of show_Members_infor){
             showInfor.addEventListener('click', showMember_infor)
         }

         //nghe hanh vi click vao button close
         closeTest.addEventListener('click', hideMember_infor);
         modelClose.addEventListener('click', hideBuyTicket);
         modalClose.addEventListener('click',  hide_bill);
         


         
	}





 //====================================hien thong tin show====================================
//====================================hien thong tin show====================================
//====================================hien thong tin show====================================
//====================================hien thong tin show====================================
//====================================hien thong tin show====================================
//====================================hien thong tin show====================================
//====================================hien thong tin show====================================
//====================================hien thong tin show====================================
/*
				          //https://localhost:44315/api/show/public/byid?idShow=2
				          //function showInfo(idShow){
				          	var url = new URL('https://localhost:44315/api/show/public/byid')

				              var params = { idShow: 2} 

				              url.search = new URLSearchParams(params).toString();

				              fetch(url)
				              .then(response => response.json())
				                .then(data => {
				                  console.log('Success:', data);
				          		
					          		document.getElementById('show-img1').src = `data:image/png;base64, ${data.dsHinhAnh}`;
					          		document.getElementById("show-name1").innerHTML=data.tenShow;
					          		document.getElementById('show-time1').innerHTML=data.thoiDiemBieuDien;
					          		document.getElementById('show-place1').innerHTML=data.diaDiem;
				          			document.getElementById('show1').name=data.idShow;
				          						          		
				                })
				                .catch((error) => {
				                  console.error('Error:', error);
				                });
				          //}

*/




	var getAPI = 'https://localhost:44315/api/show/public/all';
	function start() {
		getMembers(renderMembers);
	}

	start();
	function getMembers(callback) {
		fetch(getAPI)
			.then(function(response) {
				return response.json();
			})
			.then(callback);
	}
	
	

	function renderMembers(members) {
		var memberInfo = document.querySelector('#ticket-place-list');

		var htmls = members.map(function(member) {
				
				return `
      			<div class="ticket-place-item" >
					<img class="ticket-img" id="show-img" src="data:image/png;base64,${member.hinhAnh}"
						alt="Ha Noi">
					<div class="content-ticket">
						
						<p class="time" id="show-time">Thời điểm mở bán: ${member.thoiDiemMoBan}</p>
						
						<button class="buy-ticket" id="show" name="1" onClick="reply_click(this.id)">Buy Tickets</button>
					</div>
				</div>
      		`;
			
		});
		


		
		

	

		
		
      
//====================================hien thong tin bill====================================
//====================================hien thong tin bill====================================

		function showBillInfo(idBill){
			var url = new URL('https://localhost:44315/api/show/hoadon')
		
		    var params = { idHoaDon: idBill} 
		    
		
		    url.search = new URLSearchParams(params).toString();
		
		    fetch(url)
		    .then(response => response.json())
		      .then(data => {
		        console.log('Success:', data);
				document.getElementById('modal_bill-place').innerHTML="Địa điểm: "+data.diaDiem;
				document.getElementById('modal_bill-listTicket').innerHTML="Danh sách mã số vé: "+data.dsMaSoVe;
				document.getElementById('modal_bill-price').innerHTML="Giá: "+data.gia;
				document.getElementById('modal_bill-billID').innerHTML="Mã hóa đơn: "+data.idHoaDon;
				document.getElementById('modal_bill-transDate').innerHTML="Ngày giao dịch: "+data.ngayGiaoDich;
				document.getElementById('modal_bill-sdt').innerHTML="SDT: "+data.sdt;
				document.getElementById('modal_bill-quantity').innerHTML="Số lượng: "+data.soLuong;
				document.getElementById('modal_bill-typeTicket').innerHTML="Tên loại vé: "+data.tenLoai;
				document.getElementById('modal_bill-showName').innerHTML="Tên show: "+data.tenShow;
				document.getElementById('modal_bill-time').innerHTML="Thời điểm biểu diễn:"+data.thoiDiemBieuDien;
				
		      })
		      .catch((error) => {
		        console.error('Error:', error);
		      });
		             
			}
								
 /*<!-- ============================================================================================ -->
 <!-- =============================================lay thong tin ve======================== -->

 function reply_click(clicked_id)
 {
	 var IdShow =  document.getElementById(clicked_id).name;
	 console.log(IdShow);
 }
*/

var IdShow;

function reply_click(clicked_id)
  {
      console.log(clicked_id);
  }

				            
				            document.getElementById("pay").onclick= function(){
				            	var stk = document.getElementById("STK").value.toString();
				            	var pin = document.getElementById("PIN").value;
				            	var idShow = "9";
				            	var sdt = document.getElementById("SDT").value;
				            	var payment = document.getElementById("cost").innerHTML;
				            	

				            	
						
				        //==============đặt vé===================================    	
				            	  const dataShow = {
				                        "IdShow":9,//get IDShow
				                        "IdLoaiVe":Number(idLoaiVe),
				                        "SoLuong":Number(SoLuong),
				                        "SDT":sdt,
				                        "Account": stk,
				                        "Password":pin
				                    };
				                  //https://localhost:44315/api/show/booking
				                         fetch('https://localhost:44315/api/show/booking', {
				                          method: 'POST', // or 'PUT'
				                          headers: {
				                            'Content-Type': 'application/json',
				                          },
				                           body: JSON.stringify(dataShow),
				                        })
				                          .then(response => response.json())
				                          .then(data => {
				                            console.log('Success:', data);
				                            if(data>0){
				                            	alert("Đăt vé thành công !!!");
								
												
				                            	showBill();
				                            }
				                            else{
				                            	if(data == -5){
				                            		alert("hết vé");
				                            	}
				                            	if(data == -3){
				                            		alert("Sai thông tin tk, vui lòng kiểu tra lại");
				                            	}
				                            	if(data== -1){
				                            		alert("Số dư tài khoản không đủ");
				                            	}
				                            	if(data == -6){
				                            		//showBill();
				                            		//showBillInfo(7);
				                            		alert("Ngoài thời gian đặt vé");
													console.log(data);
				                            	}
				                            }
											//	console.log(data);
				              					
				                          })
				                          .catch((error) => {
				                            console.error('Error:', error);
				                          });
				                  
				                  			      
				            			    
				            	
				            //lấy loại vé		            	
				            	var LoaiVe = document.getElementsByName("choose_ticket");
				                            for (var i = 0; i < idLoaiVe.length; i++){
				                                if (idLoaiVe[i].checked === true){
				                                  
				            						if(idLoaiVe[i].id == "normal"){
				            							return idLoaiVe = 1;						
				            						}
				            						if(idLoaiVe[i].id == "vip"){
				            							return idLoaiVe = 2;
				            						}
				            						if(idLoaiVe[i].id == "vvip"){
				            							return idLoaiVe = 3;
				            						}
				                                }
				                            }
				                            
				            	
				                //lấy Số lượng vé
				            	var quantity = document.getElementsByName("quantity");
	                            for (var i = 0; i < SoLuong.length; i++){
	                                if (quantity[i].checked === true){
	                                   
	            						if(quantity[i].id == "one"){
	            							return SoLuong = 1;						
	            						}
	            						if(quantity[i].id == "two"){
	            							return SoLuong = 2;
	            						}
	            						if(quantity[i].id == "three"){
	            							return SoLuong = 3;
	            						}
	                                }
	                            }

										console.log(idLoaiVe);
				                        console.log(SoLuong);
				                        console.log(sdt);
				                        console.log(stk);
				                        console.log(pin);
				                        console.log(payment);
				                        console.log(dataShow);	
									
	                         	                            
				            }
	
	memberInfo.innerHTML = htmls.join('');



//========================================use modal====================================
//========================================use modal====================================
//========================================use modal====================================
 
	
			
         const buyBtns = document.querySelectorAll('.buy-ticket')
         const model = document.querySelector('.model')
         
       	 const show_Members_infor = document.querySelectorAll('.member-item')
         const model_member = document.querySelector('.model_member_infor')
         
         const modal_bill = document.querySelector('.modal_bill')
		const modalClose = document.querySelector('.js-close-Bill')
         
         const modelClose = document.querySelector('.js-model-close')
         const closeTest = document.querySelector('.js-close-memberInfo')
         

         //ham hien phan mua ve (them class openModel vao the model)
         function showBuyTicket(){
             model.classList.add('openModel')     
            // IdShow = documemt.getElementById('this.id').name;
            // console.log(IdShow);
         }
         function showMember_infor(){
             model_member.classList.add('openModel')
             
         }
		
         
         //ham an pham mua ve (xoa class openModel di)
         function hideBuyTicket(){
             model.classList.remove('openModel')
         }

         function hideMember_infor(){
             model_member.classList.remove('openModel')
         }

        	//use modal bill
								
						        function showBill(){
						        	 modal_bill.classList.add('openModel')
						         }
						 		function hide_bill(){
						        	 modal_bill.classList.remove('openModel')
						         }

         
         //lap qua tung the button va lang nghe su kien click
  
         
         for(const buyBtn of buyBtns){
             buyBtn.addEventListener('click',showBuyTicket	)	              
         }
         for(const showInfor of show_Members_infor){
             showInfor.addEventListener('click', showMember_infor)
         }

         //nghe hanh vi click vao button close
         closeTest.addEventListener('click', hideMember_infor);
         modelClose.addEventListener('click', hideBuyTicket);


		modalClose.addEventListener('click',  hide_bill);
		
		
}


		

