
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

var IdShow;
var dsCTLoaiVe;
var idLoaiVe ;
var SoLuong;
var giaVe;
var payment = SoLuong*giaVe;
var SLMax = 3;
var validate_SoLuong;
var validate_loaiVe;

function sendEmail(){ 
	Email.send({
		Host : "smtp.elasticemail.com",
		Username : "examplemail1638@gmail.com",
		Password : "CABE18D24460A06862F6E544902426FF1D19",
	//	SecureToken: "82b11689-0754-4d54-b472-96993ca3e922",
		To : 'dvphuong1408@gmail.com',
		From : "examplemail1638@gmail.com",
		Subject : "This is the subject",
		Body : "And this is the body"
	}).then(
	  message => alert(message)
	);

}


function reply_click(clicked_id)
  {	
	IdShow = document.getElementById(clicked_id).id;
    console.log(clicked_id + "..........."+ IdShow);

 //====================================hien ds ve====================================


	console.log(clicked_id);
	var url = new URL('https://localhost:44315/api/show/byid')

    var params = {idShow: clicked_id} 
    

    url.search = new URLSearchParams(params).toString();

	console.log(url);
    fetch(url)
    .then(response => response.json())
      .then(member => {
//		console.log(member.dsChiTietLoaiVe)
		dsCTLoaiVe = member.dsChiTietLoaiVe;
		console.log("IdShow: "+ IdShow + " dsCTLoaiVe: "+dsCTLoaiVe)

//================mo page booking======================
				
		var showPlaceMember = document.querySelector(".booking_body")
		var htmlsPlace = membersTv.map(function(showMember) {
			return
			 `
			<div class="booking_showInfo">
				<div class="booking_imgShow">
					<img src="data:image/png;base64,${showMember.hinhAnh}" alt="" width="100%" height="100%">
				</div>
				<div class="booking_info">
					<div class="booking_TenShow">
						Tên Show: ${showMember.tenShow}
					</div>
					<div class="booking_DiaDiem">
						Địa Điểm: ${showMember.diaDiem}
					</div>
					<div class="booking_ngayBieuDien">
						Ngày Biểu Diễn: ${showMember.thoiDiemBieuDien}
					</div>
					<div class="booking_GioiThieu">
						
					</div>
		
				</div>
			</div>
		  `;
		
		});
		showPlaceMember.innerHTML = htmlsPlace.join('');

	  })
		

       .catch((error) => {
         console.error('Error:', error);
       });
			 				 
  }

  


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
           	//IdShow = documemt.getElementById('this.id').name;
            //console.log(IdShow);
         }
         function showMember_infor(){
             model_member.classList.add('openModel')
             
         }
 //        function showBill(){
 //       	 modal_bill.classList.add('openModel')
  //       }      
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
						alt="img place of show">
					<div class="content-ticket">
						<p class="name">Concept: ${member.tenShow}</p>
						<p class="time" id="show-time">Thời điểm mở bán: ${member.thoiDiemMoBan}</p>
						
						<p class="describe">Địa Điểm: ${member.diaDiem}</p>
						<button class="buy-ticket" id="${member.idShow}" name="1" >
							
							<a onClick="reply_click(${member.idShow})" href="./booking.html" width: 20px height: 10px>Buy Tickets</a>
						</button>
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



// // validate so luong ve
// var quantity = document.getElementsByName("quantity");
// if(quantity[0] === false && quantity[1] == false && quantity[2] ===false){
// 	validate_SoLuong ="1";
// }

// //validate loai ve
// var typeTicket = document.getElementsByClassName("typeTicket");
// if(typeTicket[0] === false && typeTicket[1] == false && typeTicket[2] ===false){
// 	validate_loaiVe ="1";
// }

var input_OTP = document.getElementById('PIN');
var btnPay = document.getElementById('pay');

//========================================lấy mã xác nhận========================
				            
				            document.getElementById('getCode').onclick= function(){
				            	var stk = document.getElementById("STK").value.toString();
				            	var OTP = document.getElementById("PIN").value;
				            	var email = document.getElementById("email").value;
				            	var sdt = document.getElementById("SDT").value;
				            	payment = document.getElementById("cost").innerHTML;
								if( stk === "" || email === ""|| sdt ===""|| validate_SoLuong ==="1" || validate_loaiVe ==="1"){
									alert("xin nhập đẩy đủ thông tin");
									return;
								}else if(payment ==="0" || payment===""){
									alert("xin kiếm tra lại thông tin vé");
									return;
								}

								

								
				            					            							
				        //==============đặt vé===================================    	
				            	  const dataShow = {
				                        "IdShow":Number(IdShow),//get IDShow
				                        "IdLoaiVe":Number(idLoaiVe),
				                        "SoLuong":Number(SoLuong),
				                        "SDT":sdt,
										"email": email,
				                        "Account": stk,
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
				                            console.log('Success:', typeof(data), data);
				                            if(data >=0){
												console.log("đã gửi mã xác nhận")
				                            	alert("nhập mã xác nhận");
				                            }
				                            else{
				                            	if(data === -5){
				                            		alert("hết vé");
													return;
				                            	}
												if(data === -4){
				                            		alert("SDT đã đặt vé rồi");
													return;
				                            	}
				                            	if(data === -8){
				                            		alert("Sai thông tin tk, vui lòng kiểu tra lại");
													return;
				                            	}
				                            	if(data=== -1){
				                            		alert("Số dư tài khoản không đủ");
													return;
				                            	}
				                            	if(data === -6){
				                            	
				                            		alert("Ngoài thời gian đặt vé");
													console.log(data);
				                            	}
				                            }
											//	console.log(data);
				              					
				                          })
				                          .catch((error) => {
				                            console.error('Error:', error);
				                          });
				                  
										console.log(idLoaiVe);
				                        console.log(SoLuong);
				                        console.log(sdt);
				                        console.log(stk);
				                        console.log(pin);
				                        console.log(payment);
				                        console.log(dataShow);	
									
	                         	                            
				            }
	
	memberInfo.innerHTML = htmls.join('');


//==================================thanh toán và lấy hóa đơn==================

document.getElementById('pay').onclick= function(){
	var OTP = document.getElementById("PIN").value;
	var email = document.getElementById("email").value;

	if(OTP ==="" || email ===""){
		alert("vui lòng nhập đủ thông tin");
	}
	
	const XacNhan= {
		"email": email,
		"MaXacNhan": OTP
	};

	fetch('https://localhost:44315/api/show/ReceiveCode', {
		method: 'POST', // or 'PUT'
		headers: {
		  'Content-Type': 'application/json',
		},
		 body: JSON.stringify(XacNhan),
	  })
		.then(response => response.json())
		.then(data => {
			if(data > 0){
				console.log("thanh toán thành công");
				showBill();
				showBillInfo(data);


				Email.send({
					Host : "smtp.yourisp.com",
					Username : "n18dccn157@student.ptithcm.edu.vn",
					Password : "n18dccn157#140800",
					To : email,
					From : "n18dccn157@student.ptithcm.edu.vn",
					Subject : "concert Bill",
					Body : "And this is the body"
				}).then(
				  message => alert(message)
				);
				
			}
			else if(data == -1){
				alert("Số dư không đủ");
				return;
			}
			else if(data == -3){
				alert("không tìm thấy thông tin, vui lòng kiểm tra lại");
				return;
			}
		})
		.catch((error) => {
			console.error('Error:', error);
		  });

}

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

		
		var normal = document.getElementById("normal");
		var vip = document.getElementById("vip");
        var vvip = document.getElementById("vvip");
		
			normal.addEventListener('click', function(){
				giaVe;
				let i = 0;
				let flag = 0;
				//===========giá vé
				console.log("IdShow: "+ IdShow + " dsCTLoaiVe: "+dsCTLoaiVe)
				while (i < dsCTLoaiVe.length){
					console.log(dsCTLoaiVe[i]);
					if(dsCTLoaiVe[i].idLoaiVe == 1){
						giaVe = dsCTLoaiVe[i].gia;
						console.log(dsCTLoaiVe[i].gia + "............"+giaVe);
						flag =1;
						break;
					}
					
					
					i++;
				}
				if(flag == 0){
					
					alert("ve loai nay da het hoac khong ban");
					giaVe = "0";										   
				}
				document.getElementById('giaVe').innerHTML = giaVe;

				//============chi tiết vé
				var postAPI ='https://localhost:44315/api/show/loai-ve'
						return fetch(postAPI)
						.then(function(response){
							return response.json();
							//== json.parse
						})
						.then(function(posts){
							var htmls = posts.map(function(post){
				                if(post.idLoaiVe == 1){
				                    document.getElementById('details').innerHTML=post.chiTiet;		
				                    idLoaiVe = post.idLoaiVe ;	                   
		
								
				                }
						});
					});
			})
			vip.addEventListener('click', function(){
				giaVe;
				let i = 0;
				let flag = 0;
				console.log("IdShow: "+ IdShow + " dsCTLoaiVe: "+dsCTLoaiVe)
				//==============loại vé
				while (i < dsCTLoaiVe.length){
					console.log(dsCTLoaiVe[i]);
					
					if(dsCTLoaiVe[i].idLoaiVe == 2){
						flag = 1;
						giaVe = dsCTLoaiVe[i].gia;
						console.log(dsCTLoaiVe[i].gia + "........."+giaVe);			
								
						break;
					}									
					i++;
				}
				if(flag == 0){
					
					alert("ve loai nay da het hoac khong ban");
					giaVe = "0";										   
				}
				
				document.getElementById('giaVe').innerHTML = giaVe;

				//=============chi tiết vé
				var postAPI ='https://localhost:44315/api/show/loai-ve'
						return fetch(postAPI)
						.then(function(response){
							return response.json();
							//== json.parse
						})
						.then(function(posts){
							var htmls = posts.map(function(post){
				                if(post.idLoaiVe == 2){
				                    document.getElementById('details').innerHTML=post.chiTiet;		
				                    idLoaiVe = post.idLoaiVe ;	                   
		
								
				                }
						});
					});
			})
			vvip.addEventListener('click', function(){
				giaVe;
				let i = 0;
				let flag = 0;
				console.log("IdShow: "+ IdShow + " dsCTLoaiVe: "+dsCTLoaiVe)
				//==============giá vé
				while (i < dsCTLoaiVe.length){
					console.log(dsCTLoaiVe[i]);
					if(dsCTLoaiVe[i].idLoaiVe == 3){
						flag = 1;
						giaVe = dsCTLoaiVe[i].gia;
						console.log(dsCTLoaiVe[i].gia + "........."+giaVe);											
						break;
					}				
					i++;
				}
				if(flag == 0){
					
					alert("ve loai nay da het hoac khong ban");
					giaVe = "0";										   
				}
				document.getElementById('giaVe').innerHTML = giaVe;

				//===============chi tiết vé
				var postAPI ='https://localhost:44315/api/show/loai-ve'
						return fetch(postAPI)
						.then(function(response){
							return response.json();
							//== json.parse
						})
						.then(function(posts){
							var htmls = posts.map(function(post){
				                if(post.idLoaiVe == 3){
				                    document.getElementById('details').innerHTML=post.chiTiet;		
				                    idLoaiVe = post.idLoaiVe ;	                   
		
								
				                }
						});
					});

			})	

			var one = document.getElementById("one");
			var two = document.getElementById("two");
			var three = document.getElementById("three");
			one.addEventListener('click', function(){	
				SoLuong = one.value;											
				document.getElementById("cost").innerHTML = giaVe*SoLuong;			
			})
						      
			two.addEventListener('click', function(){
				SoLuong = two.value;															
				document.getElementById("cost").innerHTML = giaVe*SoLuong;
			})
				            
			three.addEventListener('click', function(){
				SoLuong = three.value;
				document.getElementById("cost").innerHTML = giaVe*SoLuong;
				
			});
		

	
}


		

