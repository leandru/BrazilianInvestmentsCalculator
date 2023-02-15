# BrazilianInvestmentsCalculator

<h4>Running on Docker</h4>
<p><i>docker run -d --name brinvestmentscalc-api -p 5000:5000 leandrualmeida/brinvestmentscalc-api:latest</i></p>
Browse to swagger: http://localhost:5000/swagger/index.html
<h4>Build and Run</h4>
<p>git clone https://github.com/leandru/BrazilianInvestmentsCalculator.git</p>
<b>Step 1 (on the repo root's folder)</b>
<br/>
docker build -t brinvestmentscalc-api .
<br/>
<b>Step 2</b>
<br/>
docker run -d --name brinvestmentscalc-api -p 5000:5000 brinvestmentscalc-api 

<h4>Running Tests</h4>
docker build --target testrunner -t brinvestmentscalc-tests .
<br/>
docker run brinvestmentscalc-tests

