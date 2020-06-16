
<script>
    function preview(event)
    {
        const input = event.target.files[0];

        const reader = new FileReader();

        reader.onload = function () {
            const result = reader.result;
            const img = document.getElementById('img');
            img.src = result;
        }
        reader.readAsDataURL(input);
    }</script>