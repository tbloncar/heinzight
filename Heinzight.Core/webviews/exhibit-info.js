document.addEventListener('DOMContentLoaded',function(event){
	var els = document.getElementsByClassName('main-bullet');

	console.log(els);

	for(i = 0; i < els.length; i++){

	els[i].onclick = function(){
		for(j = 0; j < els.length; j++){
			els[j].classList.remove('active');
		}
		this.classList.add('active');
	};
	}
});