# BrazilianInvestmentsCalculator


<h4>Running on Docker</h4>
<p><i>docker run -d --name brinvestmentscalc-api -p 5000:5000 leandrualmeida/brinvestmentscalc-api:latest</i></p>
Browse to swagger: http://localhost:5000/swagger/index.html
<h4>Build Steps</h4>
git clone https://github.com/leandru/BrazilianInvestmentsCalculator.git
<h5>Step 1 (on the repo root's folder)</h5>
docker build -t brinvestmentscalc-api:latest -f src/InvestmentCalculator.API/Dockerfile .
<h5>Step 2</h5>
docker run -d --name brinvestmentscalc-api -p 5000:5000 brinvestmentscalc-api:latest 

