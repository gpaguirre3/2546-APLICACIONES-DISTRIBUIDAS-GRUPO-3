from flask import Flask, render_template_string, request
from zeep import Client

app = Flask(__name__)

@app.route('/', methods=['GET', 'POST'])
def index():
    client = Client('http://www.dneonline.com/calculator.asmx?WSDL')

    intA = request.form.get('intA', 1020)
    intB = request.form.get('intB', 20)

    # Realizar operaciones
    try:
        # Suma
        sum_result = client.service.Add(intA=int(intA), intB=int(intB))

        # Resta
        sub_result = client.service.Subtract(intA=int(intA), intB=int(intB))

        # Multiplicación
        mul_result = client.service.Multiply(intA=int(intA), intB=int(intB))

        # División
        div_result = client.service.Divide(intA=int(intA), intB=int(intB))

        results = {
            "sum": sum_result,
            "sub": sub_result,
            "mul": mul_result,
            "div": div_result
        }

    except Exception as e:
        results = {"error": str(e)}

    html_content = '''
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Resultados de las operaciones</title>
        <style>
            body {
                font-family: 'Arial', sans-serif;
                background-color: #f0f8ff;
                margin: 0;
                padding: 0;
                display: flex;
                justify-content: center;
                align-items: center;
                height: 100vh;
            }
            .container {
                background-color: #fff;
                padding: 20px;
                border-radius: 8px;
                box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
                max-width: 600px;
                width: 100%;
                text-align: center;
            }
            h1 {
                color: #333;
                margin-bottom: 20px;
                font-size: 24px;
            }
            p {
                color: #555;
                font-size: 18px;
                line-height: 1.6;
            }
            .error {
                color: red;
                font-weight: bold;
            }
            form {
                margin-bottom: 20px;
            }
            input[type="number"] {
                padding: 10px;
                font-size: 16px;
                margin: 5px;
                width: 80px;
                border: 1px solid #ccc;
                border-radius: 4px;
            }
            input[type="submit"] {
                padding: 10px 20px;
                font-size: 16px;
                background-color: #007bff;
                color: #fff;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                transition: background-color 0.3s ease;
            }
            input[type="submit"]:hover {
                background-color: #0056b3;
            }
        </style>
    </head>
    <body>
        <div class="container">
            <h1>Resultados de las operaciones</h1>
            <form method="post">
                <input type="number" name="intA" value="{{ intA }}" required>
                <input type="number" name="intB" value="{{ intB }}" required>
                <input type="submit" value="Calcular">
            </form>
            <p>Numero 1: {{ intA }}</p>
            <p>Numero 2: {{ intB }}</p>
            <p>Resultado de la suma: {{ results.sum }}</p>
            <p>Resultado de la resta: {{ results.sub }}</p>
            <p>Resultado de la multiplicación: {{ results.mul }}</p>
            <p>Resultado de la división: {{ results.div }}</p>
            {% if results.error %}
                <p class="error">Error: {{ results.error }}</p>
            {% endif %}
        </div>
    </body>
    </html>
    '''

    return render_template_string(html_content, results=results, intA=intA, intB=intB)

if __name__ == '__main__':
    app.run(debug=True)