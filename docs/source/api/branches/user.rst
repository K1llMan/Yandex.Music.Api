YUserAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public Task AuthorizeAsync(AuthStorage storage, string login, string password)

Авторизация в асинхронном режиме с использованием логина и пароля.

.. code-block:: csharp

   public void Authorize(AuthStorage storage, string login, string password)

Авторизация с использованием логина и пароля.

.. tip:: Рекомендуется использовать эти методы только для первоначального получения токена, а в дальнейшем использовать его.


.. code-block:: csharp

   public Task AuthorizeAsync(AuthStorage storage, string token)

Авторизация в асинхронном режиме с использованием токена.

.. code-block:: csharp

   public void Authorize(AuthStorage storage, string token)

Авторизация с использованием токена.

.. warning:: Необходимо обязательно выполнить авторизацию перед использованием функционала API.
 
.. code-block:: csharp

   public Task<YResponse<YAccountResult>> GetUserAuthAsync(AuthStorage storage)

Получение информации об авторизации в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YAccountResult> GetUserAuth(AuthStorage storage)

Получение информации об авторизации.

.. code-block:: csharp

   public Task<YAuthTypes> CreateAuthSessionAsync(AuthStorage storage, string userName)

Создание сеанса и получение доступных методов авторизации в асинхронном режиме.

.. code-block:: csharp

   public YAuthTypes CreateAuthSession(AuthStorage storage, string userName)

Создание сеанса и получение доступных методов авторизации.

.. code-block:: csharp

   public Task<string> GetAuthQRLinkAsync(AuthStorage storage)

Получение ссылки на QR-код в асинхронном режиме.

.. code-block:: csharp

   public string GetAuthQRLink(AuthStorage storage)

Получение ссылки на QR-код.

.. code-block:: csharp

   public Task<bool> LoginByQRAsync(AuthStorage storage)

Авторизация по QR-коду в асинхронном режиме.

.. code-block:: csharp

   public bool LoginByQR(AuthStorage storage)

Авторизация по QR-коду.

.. code-block:: csharp

   public Task<YAuthCaptcha> GetCaptchaAsync(AuthStorage storage)

Получение данных captcha в асинхронном режиме.

.. code-block:: csharp

   public YAuthCaptcha GetCaptcha(AuthStorage storage)

Получение данных captcha.

.. code-block:: csharp

   public Task<YAuthBase> LoginByCaptchaAsync(AuthStorage storage, string captchaValue)

Авторизация по captcha в асинхронном режиме.

.. code-block:: csharp

   public YAuthBase LoginByCaptcha(AuthStorage storage, string captchaValue)

Авторизация по captcha.

.. code-block:: csharp

   public Task<YAuthLetter> GetAuthLetterAsync(AuthStorage storage)

Получение письма авторизации на почту пользователя в асинхронном режиме.

.. code-block:: csharp

   public YAuthLetter GetAuthLetter(AuthStorage storage)

Получение письма авторизации на почту пользователя.

.. code-block:: csharp

   public Task<YAccessToken> LoginByLetterAsync(AuthStorage storage)

Авторизация после подтверждения входа через письмо в асинхронном режиме.

.. code-block:: csharp

   public YAccessToken LoginByLetter(AuthStorage storage)

Авторизация после подтверждения входа через письмо.

.. code-block:: csharp

   public Task<YAccessToken> LoginByAppPasswordAsync(AuthStorage storage, string password)

Авторизация с помощью пароля из приложения Яндекс в асинхронном режиме.

.. code-block:: csharp

   public YAccessToken LoginByAppPassword(AuthStorage storage, string password)

Авторизация с помощью пароля из приложения Яндекс.

.. code-block:: csharp

   public Task<YAccessToken> GetAccessTokenAsync(AuthStorage storage)

Метод позволяет получить AcessToken после выполнения авторизации посредством QR, Mail, App password.

.. code-block:: csharp

   public Task<YAccessToken> GetAccessToken(AuthStorage storage)

Метод позволяет получить AcessToken после выполнения авторизации посредством QR, Mail, App password.