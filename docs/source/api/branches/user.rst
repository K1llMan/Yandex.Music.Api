YUserAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task AuthorizeAsync(AuthStorage storage, string login, string password)

Авторизация в асинхронном режиме с использованием логина и пароля.

.. code-block:: csharp

   public void Authorize(AuthStorage storage, string login, string password)

Авторизация с использованием логина и пароля.

.. tip:: Рекомендуется использовать эти методы только для первоначального получения токена, а в дальнейшем использовать его.


.. code-block:: csharp

   public async Task AuthorizeAsync(AuthStorage storage, string token)

Авторизация в асинхронном режиме с использованием токена.

.. code-block:: csharp

   public void Authorize(AuthStorage storage, string token)

Авторизация с использованием токена.

.. warning:: Необходимо обязательно выполнить авторизацию перед использованием функционала API.
 
.. code-block:: csharp

   public async Task<YResponse<YAccountResult>> GetUserAuthAsync(AuthStorage storage)

Получение информации об авторизации в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YAccountResult> GetUserAuth(AuthStorage storage)

Получение информации об авторизации.