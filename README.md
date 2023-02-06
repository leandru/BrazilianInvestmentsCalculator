# BrazilianInvestmentsCalculator

<h3>Local host using Docker</h3>
<h4>Step 1</h4>
git clone https://github.com/leandru/BrazilianInvestmentsCalculator.git
<h4>Step 2 (on the repo root's folder)</h4>
docker build -t brinvestmentscalc-api:latest -f src/InvestmentCalculator.API/Dockerfile .
<h4>Step 3</h4>
docker run -d --name brinvestmentscalc-api -p 5000:5000 brinvestmentscalc-api:latest 
<h4>Step 4 (Browse)</h4>
http://localhost:5000/swagger/index.html
