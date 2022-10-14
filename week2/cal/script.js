$(document).ready(function () {
    let num_array=[];
    let op_array=[];
    let screen = $('.screen');

    $('button.num').click(function (e) {
        let num_s = $(this).val();
        let num_i = parseInt(num_s);
        num_array.push(num_i);
       screen_dis(num_s);
    });

    $('button.op').click(function(){
        let op_s = $(this).val();
        op_array.push(op_s);
        if(op_s == '='){
            let result = cal(num_array[0], num_array[1], op_array[0]);;
            op_array.pop();
            for(let i = 1; i < op_array.length; i ++){
                console.log(result, num_array[i+1]);
                result = cal(result, num_array[i+1], op_array[i]);

            }
            screen_dis('all');
            screen_dis(result.toString());
            num_array=[];
            num_array.push(result);
            op_array=[];
        }else if(op_s == 'clear'){
            screen_dis('all');
            num_array=[];
            op_array=[];
        }else {
            screen_dis(op_s);
        }
    });

    function cal(num1, num2, op){
        let result=0;
        if(op == '+'){
            result = num1 + num2;
        }else if(op=='-'){
            result = num1 - num2;
        }else if( op == '*'){
            result = num1 * num2;
        }else {
            result = num1 / num2;
        }
        return result;
    }

    function screen_dis(el){
         let screen_text_value = screen.text();
         screen.text(screen_text_value + el);

         if(el == 'all'){
             screen.text('');
         }
    }
})