# NumbersToText

<b>Architecture</b>
<p>This project is developed using MVC pattern. <br/>
Angular JS is used on the client end as it is suited for MVC pattern. <br/>
On the back end, AKQA.BL will contain all the necessary logic to process data<br/>
and the WebApp will contain the logic to generate Web Page and handle request via web api.
</p>
<b>Numbers Object</b>
<p>
Numbers object in AKQA.BL Namespace process numbers in the following sequence. We will use "123.04" as example<br/>

1. Split the number into characteristic and mantissa.
<br/>characteristic is 123
<br/>mantissa is 4<br/>

2. Extract the most significant number (first number on the left) which is 1 and determine the value. In this case it is 100 and therefore ONE HUNDRED.
3. Get the next significant number which is 2 and determine the value. For this it is 20 and therefore ONE HUNDRED AND TWENTY.
4. Get the least significant number which is 3 and determine the value. For this it is 3 and therefore ONE HUNDRED AND TWENTY-THREE.
5. Do the same for the mantissa and it will determine it as FOUR.

</p>
