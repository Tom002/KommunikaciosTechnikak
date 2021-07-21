// AddProductResultFactory.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProductResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.AddProductResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;

        public AddProductResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult);

        public AddProductResult Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is AddProductResultInfo info)
            {
                return new AddProductResult(MapNonNullableIAddProduct_AddProduct(
                    info.AddProduct,
                    snapshot));
            }

            throw new global::System.ArgumentException("AddProductResultInfo expected.");
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProduct_AddProduct MapNonNullableIAddProduct_AddProduct(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AddProductPayloadData data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            IAddProduct_AddProduct returnValue = default!;

            if (data.__typename.Equals(
                    "AddProductPayload",
                    global::System.StringComparison.Ordinal))
            {
                returnValue = new AddProduct_AddProduct_AddProductPayload(MapIAddProduct_AddProduct_Product(
                    data.Product,
                    snapshot));
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProduct_AddProduct_Product? MapIAddProduct_AddProduct_Product(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData? data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (data is null)
            {
                return null;
            }

            IAddProduct_AddProduct_Product returnValue = default!;

            if (data?.__typename.Equals(
                    "ProductDto",
                    global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new AddProduct_AddProduct_Product_ProductDto(
                    data.Name ?? throw new global::System.ArgumentNullException(),
                    data.ProductId ?? throw new global::System.ArgumentNullException(),
                    data.ProductNumber ?? throw new global::System.ArgumentNullException());
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(
                dataInfo,
                snapshot);
        }
    }
}


// AddProductResultInfo.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProductResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;

        public AddProductResultInfo(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AddProductPayloadData addProduct,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            global::System.UInt64 version)
        {
            AddProduct = addProduct;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AddProductPayloadData AddProduct { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public global::System.UInt64 Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new AddProductResultInfo(
                AddProduct,
                _entityIds,
                version);
        }
    }
}


// AddProductResult.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProductResult
        : global::System.IEquatable<AddProductResult>
        , IAddProductResult
    {
        public AddProductResult(global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProduct_AddProduct addProduct)
        {
            AddProduct = addProduct;
        }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProduct_AddProduct AddProduct { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((AddProductResult)obj);
        }

        public global::System.Boolean Equals(AddProductResult? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (AddProduct.Equals(other.AddProduct));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * AddProduct.GetHashCode();

                return hash;
            }
        }
    }
}


// AddProduct_AddProduct_AddProductPayload.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProduct_AddProduct_AddProductPayload
        : global::System.IEquatable<AddProduct_AddProduct_AddProductPayload>
        , IAddProduct_AddProduct_AddProductPayload
    {
        public AddProduct_AddProduct_AddProductPayload(global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProduct_AddProduct_Product? product)
        {
            Product = product;
        }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProduct_AddProduct_Product? Product { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((AddProduct_AddProduct_AddProductPayload)obj);
        }

        public global::System.Boolean Equals(AddProduct_AddProduct_AddProductPayload? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (((Product is null && other.Product is null) ||Product != null && Product.Equals(other.Product)));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                if (!(Product is null))
                {
                    hash ^= 397 * Product.GetHashCode();
                }

                return hash;
            }
        }
    }
}


// AddProduct_AddProduct_Product_ProductDto.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProduct_AddProduct_Product_ProductDto
        : global::System.IEquatable<AddProduct_AddProduct_Product_ProductDto>
        , IAddProduct_AddProduct_Product_ProductDto
    {
        public AddProduct_AddProduct_Product_ProductDto(
            global::System.String name,
            global::System.Int32 productId,
            global::System.String productNumber)
        {
            Name = name;
            ProductId = productId;
            ProductNumber = productNumber;
        }

        public global::System.String Name { get; }

        public global::System.Int32 ProductId { get; }

        public global::System.String ProductNumber { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((AddProduct_AddProduct_Product_ProductDto)obj);
        }

        public global::System.Boolean Equals(AddProduct_AddProduct_Product_ProductDto? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Name.Equals(other.Name))
                && ProductId == other.ProductId
                && ProductNumber.Equals(other.ProductNumber);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * Name.GetHashCode();

                hash ^= 397 * ProductId.GetHashCode();

                hash ^= 397 * ProductNumber.GetHashCode();

                return hash;
            }
        }
    }
}


// IAddProductResult.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IAddProductResult
    {
        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProduct_AddProduct AddProduct { get; }
    }
}


// IAddProduct_AddProduct.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IAddProduct_AddProduct
    {
        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProduct_AddProduct_Product? Product { get; }
    }
}


// IAddProduct_AddProduct_AddProductPayload.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IAddProduct_AddProduct_AddProductPayload
        : IAddProduct_AddProduct
    {
    }
}


// IAddProduct_AddProduct_Product.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IAddProduct_AddProduct_Product
    {
        public global::System.String Name { get; }

        public global::System.Int32 ProductId { get; }

        public global::System.String ProductNumber { get; }
    }
}


// IAddProduct_AddProduct_Product_ProductDto.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IAddProduct_AddProduct_Product_ProductDto
        : IAddProduct_AddProduct_Product
    {
    }
}


// OnProductAddedResultFactory.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class OnProductAddedResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.OnProductAddedResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;

        public OnProductAddedResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult);

        public OnProductAddedResult Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is OnProductAddedResultInfo info)
            {
                return new OnProductAddedResult(MapNonNullableIOnProductAdded_OnProductAdded(
                    info.OnProductAdded,
                    snapshot));
            }

            throw new global::System.ArgumentException("OnProductAddedResultInfo expected.");
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAdded_OnProductAdded MapNonNullableIOnProductAdded_OnProductAdded(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            IOnProductAdded_OnProductAdded returnValue = default!;

            if (data.__typename.Equals(
                    "ProductDto",
                    global::System.StringComparison.Ordinal))
            {
                returnValue = new OnProductAdded_OnProductAdded_ProductDto(
                    data.ProductId ?? throw new global::System.ArgumentNullException(),
                    data.Name ?? throw new global::System.ArgumentNullException(),
                    data.SafetyStockLevel ?? throw new global::System.ArgumentNullException(),
                    data.DaysToManufacture ?? throw new global::System.ArgumentNullException());
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(
                dataInfo,
                snapshot);
        }
    }
}


// OnProductAddedResultInfo.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class OnProductAddedResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;

        public OnProductAddedResultInfo(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData onProductAdded,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            global::System.UInt64 version)
        {
            OnProductAdded = onProductAdded;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData OnProductAdded { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public global::System.UInt64 Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new OnProductAddedResultInfo(
                OnProductAdded,
                _entityIds,
                version);
        }
    }
}


// OnProductAddedResult.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class OnProductAddedResult
        : global::System.IEquatable<OnProductAddedResult>
        , IOnProductAddedResult
    {
        public OnProductAddedResult(global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAdded_OnProductAdded onProductAdded)
        {
            OnProductAdded = onProductAdded;
        }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAdded_OnProductAdded OnProductAdded { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((OnProductAddedResult)obj);
        }

        public global::System.Boolean Equals(OnProductAddedResult? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (OnProductAdded.Equals(other.OnProductAdded));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * OnProductAdded.GetHashCode();

                return hash;
            }
        }
    }
}


// OnProductAdded_OnProductAdded_ProductDto.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class OnProductAdded_OnProductAdded_ProductDto
        : global::System.IEquatable<OnProductAdded_OnProductAdded_ProductDto>
        , IOnProductAdded_OnProductAdded_ProductDto
    {
        public OnProductAdded_OnProductAdded_ProductDto(
            global::System.Int32 productId,
            global::System.String name,
            global::System.Int16 safetyStockLevel,
            global::System.Int32 daysToManufacture)
        {
            ProductId = productId;
            Name = name;
            SafetyStockLevel = safetyStockLevel;
            DaysToManufacture = daysToManufacture;
        }

        public global::System.Int32 ProductId { get; }

        public global::System.String Name { get; }

        public global::System.Int16 SafetyStockLevel { get; }

        public global::System.Int32 DaysToManufacture { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((OnProductAdded_OnProductAdded_ProductDto)obj);
        }

        public global::System.Boolean Equals(OnProductAdded_OnProductAdded_ProductDto? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (ProductId == other.ProductId)
                && Name.Equals(other.Name)
                && SafetyStockLevel == other.SafetyStockLevel
                && DaysToManufacture == other.DaysToManufacture;
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * ProductId.GetHashCode();

                hash ^= 397 * Name.GetHashCode();

                hash ^= 397 * SafetyStockLevel.GetHashCode();

                hash ^= 397 * DaysToManufacture.GetHashCode();

                return hash;
            }
        }
    }
}


// IOnProductAddedResult.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IOnProductAddedResult
    {
        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAdded_OnProductAdded OnProductAdded { get; }
    }
}


// IOnProductAdded_OnProductAdded.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IOnProductAdded_OnProductAdded
    {
        public global::System.Int32 ProductId { get; }

        public global::System.String Name { get; }

        public global::System.Int16 SafetyStockLevel { get; }

        public global::System.Int32 DaysToManufacture { get; }
    }
}


// IOnProductAdded_OnProductAdded_ProductDto.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IOnProductAdded_OnProductAdded_ProductDto
        : IOnProductAdded_OnProductAdded
    {
    }
}


// UpdateProductResultFactory.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProductResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.UpdateProductResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;

        public UpdateProductResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult);

        public UpdateProductResult Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is UpdateProductResultInfo info)
            {
                return new UpdateProductResult(MapNonNullableIUpdateProduct_UpdateProduct(
                    info.UpdateProduct,
                    snapshot));
            }

            throw new global::System.ArgumentException("UpdateProductResultInfo expected.");
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProduct_UpdateProduct MapNonNullableIUpdateProduct_UpdateProduct(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.UpdateProductPayloadData data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            IUpdateProduct_UpdateProduct returnValue = default!;

            if (data.__typename.Equals(
                    "UpdateProductPayload",
                    global::System.StringComparison.Ordinal))
            {
                returnValue = new UpdateProduct_UpdateProduct_UpdateProductPayload(MapIUpdateProduct_UpdateProduct_Product(
                    data.Product,
                    snapshot));
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProduct_UpdateProduct_Product? MapIUpdateProduct_UpdateProduct_Product(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData? data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (data is null)
            {
                return null;
            }

            IUpdateProduct_UpdateProduct_Product returnValue = default!;

            if (data?.__typename.Equals(
                    "ProductDto",
                    global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new UpdateProduct_UpdateProduct_Product_ProductDto(
                    data.Name ?? throw new global::System.ArgumentNullException(),
                    data.ProductId ?? throw new global::System.ArgumentNullException(),
                    data.ProductNumber ?? throw new global::System.ArgumentNullException(),
                    data.MakeFlag ?? throw new global::System.ArgumentNullException(),
                    data.FinishedGoodsFlag ?? throw new global::System.ArgumentNullException(),
                    data.SafetyStockLevel ?? throw new global::System.ArgumentNullException(),
                    data.ReorderPoint ?? throw new global::System.ArgumentNullException(),
                    data.StandardCost ?? throw new global::System.ArgumentNullException(),
                    data.ListPrice ?? throw new global::System.ArgumentNullException(),
                    data.DaysToManufacture ?? throw new global::System.ArgumentNullException(),
                    data.SellStartDate ?? throw new global::System.ArgumentNullException());
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(
                dataInfo,
                snapshot);
        }
    }
}


// UpdateProductResultInfo.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProductResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;

        public UpdateProductResultInfo(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.UpdateProductPayloadData updateProduct,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            global::System.UInt64 version)
        {
            UpdateProduct = updateProduct;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.UpdateProductPayloadData UpdateProduct { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public global::System.UInt64 Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new UpdateProductResultInfo(
                UpdateProduct,
                _entityIds,
                version);
        }
    }
}


// UpdateProductResult.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProductResult
        : global::System.IEquatable<UpdateProductResult>
        , IUpdateProductResult
    {
        public UpdateProductResult(global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProduct_UpdateProduct updateProduct)
        {
            UpdateProduct = updateProduct;
        }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProduct_UpdateProduct UpdateProduct { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((UpdateProductResult)obj);
        }

        public global::System.Boolean Equals(UpdateProductResult? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (UpdateProduct.Equals(other.UpdateProduct));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * UpdateProduct.GetHashCode();

                return hash;
            }
        }
    }
}


// UpdateProduct_UpdateProduct_UpdateProductPayload.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProduct_UpdateProduct_UpdateProductPayload
        : global::System.IEquatable<UpdateProduct_UpdateProduct_UpdateProductPayload>
        , IUpdateProduct_UpdateProduct_UpdateProductPayload
    {
        public UpdateProduct_UpdateProduct_UpdateProductPayload(global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProduct_UpdateProduct_Product? product)
        {
            Product = product;
        }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProduct_UpdateProduct_Product? Product { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((UpdateProduct_UpdateProduct_UpdateProductPayload)obj);
        }

        public global::System.Boolean Equals(UpdateProduct_UpdateProduct_UpdateProductPayload? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (((Product is null && other.Product is null) ||Product != null && Product.Equals(other.Product)));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                if (!(Product is null))
                {
                    hash ^= 397 * Product.GetHashCode();
                }

                return hash;
            }
        }
    }
}


// UpdateProduct_UpdateProduct_Product_ProductDto.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProduct_UpdateProduct_Product_ProductDto
        : global::System.IEquatable<UpdateProduct_UpdateProduct_Product_ProductDto>
        , IUpdateProduct_UpdateProduct_Product_ProductDto
    {
        public UpdateProduct_UpdateProduct_Product_ProductDto(
            global::System.String name,
            global::System.Int32 productId,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate)
        {
            Name = name;
            ProductId = productId;
            ProductNumber = productNumber;
            MakeFlag = makeFlag;
            FinishedGoodsFlag = finishedGoodsFlag;
            SafetyStockLevel = safetyStockLevel;
            ReorderPoint = reorderPoint;
            StandardCost = standardCost;
            ListPrice = listPrice;
            DaysToManufacture = daysToManufacture;
            SellStartDate = sellStartDate;
        }

        public global::System.String Name { get; }

        public global::System.Int32 ProductId { get; }

        public global::System.String ProductNumber { get; }

        public global::System.Boolean MakeFlag { get; }

        public global::System.Boolean FinishedGoodsFlag { get; }

        public global::System.Int16 SafetyStockLevel { get; }

        public global::System.Int16 ReorderPoint { get; }

        public global::System.Decimal StandardCost { get; }

        public global::System.Decimal ListPrice { get; }

        public global::System.Int32 DaysToManufacture { get; }

        public global::System.DateTimeOffset SellStartDate { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((UpdateProduct_UpdateProduct_Product_ProductDto)obj);
        }

        public global::System.Boolean Equals(UpdateProduct_UpdateProduct_Product_ProductDto? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Name.Equals(other.Name))
                && ProductId == other.ProductId
                && ProductNumber.Equals(other.ProductNumber)
                && MakeFlag == other.MakeFlag
                && FinishedGoodsFlag == other.FinishedGoodsFlag
                && SafetyStockLevel == other.SafetyStockLevel
                && ReorderPoint == other.ReorderPoint
                && StandardCost == other.StandardCost
                && ListPrice == other.ListPrice
                && DaysToManufacture == other.DaysToManufacture
                && SellStartDate.Equals(other.SellStartDate);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * Name.GetHashCode();

                hash ^= 397 * ProductId.GetHashCode();

                hash ^= 397 * ProductNumber.GetHashCode();

                hash ^= 397 * MakeFlag.GetHashCode();

                hash ^= 397 * FinishedGoodsFlag.GetHashCode();

                hash ^= 397 * SafetyStockLevel.GetHashCode();

                hash ^= 397 * ReorderPoint.GetHashCode();

                hash ^= 397 * StandardCost.GetHashCode();

                hash ^= 397 * ListPrice.GetHashCode();

                hash ^= 397 * DaysToManufacture.GetHashCode();

                hash ^= 397 * SellStartDate.GetHashCode();

                return hash;
            }
        }
    }
}


// IUpdateProductResult.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IUpdateProductResult
    {
        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProduct_UpdateProduct UpdateProduct { get; }
    }
}


// IUpdateProduct_UpdateProduct.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IUpdateProduct_UpdateProduct
    {
        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProduct_UpdateProduct_Product? Product { get; }
    }
}


// IUpdateProduct_UpdateProduct_UpdateProductPayload.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IUpdateProduct_UpdateProduct_UpdateProductPayload
        : IUpdateProduct_UpdateProduct
    {
    }
}


// IUpdateProduct_UpdateProduct_Product.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IUpdateProduct_UpdateProduct_Product
    {
        public global::System.String Name { get; }

        public global::System.Int32 ProductId { get; }

        public global::System.String ProductNumber { get; }

        public global::System.Boolean MakeFlag { get; }

        public global::System.Boolean FinishedGoodsFlag { get; }

        public global::System.Int16 SafetyStockLevel { get; }

        public global::System.Int16 ReorderPoint { get; }

        public global::System.Decimal StandardCost { get; }

        public global::System.Decimal ListPrice { get; }

        public global::System.Int32 DaysToManufacture { get; }

        public global::System.DateTimeOffset SellStartDate { get; }
    }
}


// IUpdateProduct_UpdateProduct_Product_ProductDto.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IUpdateProduct_UpdateProduct_Product_ProductDto
        : IUpdateProduct_UpdateProduct_Product
    {
    }
}


// AddProductMutationDocument.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the AddProduct GraphQL operation
    /// <code>
    /// mutation AddProduct($name: String!, $productNumber: String!, $makeFlag: Boolean!, $finishedGoodsFlag: Boolean!, $safetyStockLevel: Short!, $reorderPoint: Short!, $standardCost: Decimal!, $listPrice: Decimal!, $daysToManufacture: Int!, $sellStartDate: DateTime!) {
    ///   addProduct(input: { name: $name, productNumber: $productNumber, makeFlag: $makeFlag, finishedGoodsFlag: $finishedGoodsFlag, safetyStockLevel: $safetyStockLevel, reorderPoint: $reorderPoint, standardCost: $standardCost, listPrice: $listPrice, daysToManufacture: $daysToManufacture, sellStartDate: $sellStartDate }) {
    ///     __typename
    ///     product {
    ///       __typename
    ///       name
    ///       productId
    ///       productNumber
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProductMutationDocument
        : global::StrawberryShake.IDocument
    {
        private AddProductMutationDocument()
        {
        }

        public static AddProductMutationDocument Instance { get; } = new AddProductMutationDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Mutation;

        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{ 0x6d, 0x75, 0x74, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x20, 0x41, 0x64, 0x64, 0x50, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x28, 0x24, 0x6e, 0x61, 0x6d, 0x65, 0x3a, 0x20, 0x53, 0x74, 0x72, 0x69, 0x6e, 0x67, 0x21, 0x2c, 0x20, 0x24, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x4e, 0x75, 0x6d, 0x62, 0x65, 0x72, 0x3a, 0x20, 0x53, 0x74, 0x72, 0x69, 0x6e, 0x67, 0x21, 0x2c, 0x20, 0x24, 0x6d, 0x61, 0x6b, 0x65, 0x46, 0x6c, 0x61, 0x67, 0x3a, 0x20, 0x42, 0x6f, 0x6f, 0x6c, 0x65, 0x61, 0x6e, 0x21, 0x2c, 0x20, 0x24, 0x66, 0x69, 0x6e, 0x69, 0x73, 0x68, 0x65, 0x64, 0x47, 0x6f, 0x6f, 0x64, 0x73, 0x46, 0x6c, 0x61, 0x67, 0x3a, 0x20, 0x42, 0x6f, 0x6f, 0x6c, 0x65, 0x61, 0x6e, 0x21, 0x2c, 0x20, 0x24, 0x73, 0x61, 0x66, 0x65, 0x74, 0x79, 0x53, 0x74, 0x6f, 0x63, 0x6b, 0x4c, 0x65, 0x76, 0x65, 0x6c, 0x3a, 0x20, 0x53, 0x68, 0x6f, 0x72, 0x74, 0x21, 0x2c, 0x20, 0x24, 0x72, 0x65, 0x6f, 0x72, 0x64, 0x65, 0x72, 0x50, 0x6f, 0x69, 0x6e, 0x74, 0x3a, 0x20, 0x53, 0x68, 0x6f, 0x72, 0x74, 0x21, 0x2c, 0x20, 0x24, 0x73, 0x74, 0x61, 0x6e, 0x64, 0x61, 0x72, 0x64, 0x43, 0x6f, 0x73, 0x74, 0x3a, 0x20, 0x44, 0x65, 0x63, 0x69, 0x6d, 0x61, 0x6c, 0x21, 0x2c, 0x20, 0x24, 0x6c, 0x69, 0x73, 0x74, 0x50, 0x72, 0x69, 0x63, 0x65, 0x3a, 0x20, 0x44, 0x65, 0x63, 0x69, 0x6d, 0x61, 0x6c, 0x21, 0x2c, 0x20, 0x24, 0x64, 0x61, 0x79, 0x73, 0x54, 0x6f, 0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x3a, 0x20, 0x49, 0x6e, 0x74, 0x21, 0x2c, 0x20, 0x24, 0x73, 0x65, 0x6c, 0x6c, 0x53, 0x74, 0x61, 0x72, 0x74, 0x44, 0x61, 0x74, 0x65, 0x3a, 0x20, 0x44, 0x61, 0x74, 0x65, 0x54, 0x69, 0x6d, 0x65, 0x21, 0x29, 0x20, 0x7b, 0x20, 0x61, 0x64, 0x64, 0x50, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x28, 0x69, 0x6e, 0x70, 0x75, 0x74, 0x3a, 0x20, 0x7b, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x3a, 0x20, 0x24, 0x6e, 0x61, 0x6d, 0x65, 0x2c, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x4e, 0x75, 0x6d, 0x62, 0x65, 0x72, 0x3a, 0x20, 0x24, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x4e, 0x75, 0x6d, 0x62, 0x65, 0x72, 0x2c, 0x20, 0x6d, 0x61, 0x6b, 0x65, 0x46, 0x6c, 0x61, 0x67, 0x3a, 0x20, 0x24, 0x6d, 0x61, 0x6b, 0x65, 0x46, 0x6c, 0x61, 0x67, 0x2c, 0x20, 0x66, 0x69, 0x6e, 0x69, 0x73, 0x68, 0x65, 0x64, 0x47, 0x6f, 0x6f, 0x64, 0x73, 0x46, 0x6c, 0x61, 0x67, 0x3a, 0x20, 0x24, 0x66, 0x69, 0x6e, 0x69, 0x73, 0x68, 0x65, 0x64, 0x47, 0x6f, 0x6f, 0x64, 0x73, 0x46, 0x6c, 0x61, 0x67, 0x2c, 0x20, 0x73, 0x61, 0x66, 0x65, 0x74, 0x79, 0x53, 0x74, 0x6f, 0x63, 0x6b, 0x4c, 0x65, 0x76, 0x65, 0x6c, 0x3a, 0x20, 0x24, 0x73, 0x61, 0x66, 0x65, 0x74, 0x79, 0x53, 0x74, 0x6f, 0x63, 0x6b, 0x4c, 0x65, 0x76, 0x65, 0x6c, 0x2c, 0x20, 0x72, 0x65, 0x6f, 0x72, 0x64, 0x65, 0x72, 0x50, 0x6f, 0x69, 0x6e, 0x74, 0x3a, 0x20, 0x24, 0x72, 0x65, 0x6f, 0x72, 0x64, 0x65, 0x72, 0x50, 0x6f, 0x69, 0x6e, 0x74, 0x2c, 0x20, 0x73, 0x74, 0x61, 0x6e, 0x64, 0x61, 0x72, 0x64, 0x43, 0x6f, 0x73, 0x74, 0x3a, 0x20, 0x24, 0x73, 0x74, 0x61, 0x6e, 0x64, 0x61, 0x72, 0x64, 0x43, 0x6f, 0x73, 0x74, 0x2c, 0x20, 0x6c, 0x69, 0x73, 0x74, 0x50, 0x72, 0x69, 0x63, 0x65, 0x3a, 0x20, 0x24, 0x6c, 0x69, 0x73, 0x74, 0x50, 0x72, 0x69, 0x63, 0x65, 0x2c, 0x20, 0x64, 0x61, 0x79, 0x73, 0x54, 0x6f, 0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x3a, 0x20, 0x24, 0x64, 0x61, 0x79, 0x73, 0x54, 0x6f, 0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x2c, 0x20, 0x73, 0x65, 0x6c, 0x6c, 0x53, 0x74, 0x61, 0x72, 0x74, 0x44, 0x61, 0x74, 0x65, 0x3a, 0x20, 0x24, 0x73, 0x65, 0x6c, 0x6c, 0x53, 0x74, 0x61, 0x72, 0x74, 0x44, 0x61, 0x74, 0x65, 0x20, 0x7d, 0x29, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x49, 0x64, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x4e, 0x75, 0x6d, 0x62, 0x65, 0x72, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x7d };

        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("sha1Hash", "3a1de2db467f70b323c689b08f05c0aa41376895");

        public override global::System.String ToString()
        {
            #if NETSTANDARD2_0
            return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
            #else
            return global::System.Text.Encoding.UTF8.GetString(Body);
            #endif
        }
    }
}


// AddProductMutation.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the AddProduct GraphQL operation
    /// <code>
    /// mutation AddProduct($name: String!, $productNumber: String!, $makeFlag: Boolean!, $finishedGoodsFlag: Boolean!, $safetyStockLevel: Short!, $reorderPoint: Short!, $standardCost: Decimal!, $listPrice: Decimal!, $daysToManufacture: Int!, $sellStartDate: DateTime!) {
    ///   addProduct(input: { name: $name, productNumber: $productNumber, makeFlag: $makeFlag, finishedGoodsFlag: $finishedGoodsFlag, safetyStockLevel: $safetyStockLevel, reorderPoint: $reorderPoint, standardCost: $standardCost, listPrice: $listPrice, daysToManufacture: $daysToManufacture, sellStartDate: $sellStartDate }) {
    ///     __typename
    ///     product {
    ///       __typename
    ///       name
    ///       productId
    ///       productNumber
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProductMutation
        : global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductMutation
    {
        private readonly global::StrawberryShake.IOperationExecutor<IAddProductResult> _operationExecutor;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _stringFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _booleanFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _shortFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _decimalFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _intFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _dateTimeFormatter;

        public AddProductMutation(
            global::StrawberryShake.IOperationExecutor<IAddProductResult> operationExecutor,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
            _stringFormatter = serializerResolver.GetInputValueFormatter("String");
            _booleanFormatter = serializerResolver.GetInputValueFormatter("Boolean");
            _shortFormatter = serializerResolver.GetInputValueFormatter("Short");
            _decimalFormatter = serializerResolver.GetInputValueFormatter("Decimal");
            _intFormatter = serializerResolver.GetInputValueFormatter("Int");
            _dateTimeFormatter = serializerResolver.GetInputValueFormatter("DateTime");
        }

        global::System.Type global::StrawberryShake.IOperationRequestFactory.ResultType => typeof(IAddProductResult);

        public async global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IAddProductResult>> ExecuteAsync(
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = CreateRequest(
                name,
                productNumber,
                makeFlag,
                finishedGoodsFlag,
                safetyStockLevel,
                reorderPoint,
                standardCost,
                listPrice,
                daysToManufacture,
                sellStartDate);

            return await _operationExecutor
                .ExecuteAsync(
                    request,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IAddProductResult>> Watch(
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate,
            global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest(
                name,
                productNumber,
                makeFlag,
                finishedGoodsFlag,
                safetyStockLevel,
                reorderPoint,
                standardCost,
                listPrice,
                daysToManufacture,
                sellStartDate);
            return _operationExecutor.Watch(
                request,
                strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate)
        {
            var variables = new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>();

            variables.Add(
                "name",
                FormatName(name));
            variables.Add(
                "productNumber",
                FormatProductNumber(productNumber));
            variables.Add(
                "makeFlag",
                FormatMakeFlag(makeFlag));
            variables.Add(
                "finishedGoodsFlag",
                FormatFinishedGoodsFlag(finishedGoodsFlag));
            variables.Add(
                "safetyStockLevel",
                FormatSafetyStockLevel(safetyStockLevel));
            variables.Add(
                "reorderPoint",
                FormatReorderPoint(reorderPoint));
            variables.Add(
                "standardCost",
                FormatStandardCost(standardCost));
            variables.Add(
                "listPrice",
                FormatListPrice(listPrice));
            variables.Add(
                "daysToManufacture",
                FormatDaysToManufacture(daysToManufacture));
            variables.Add(
                "sellStartDate",
                FormatSellStartDate(sellStartDate));

            return CreateRequest(variables);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {

            return new global::StrawberryShake.OperationRequest(
                id: AddProductMutationDocument.Instance.Hash.Value,
                name: "AddProduct",
                document: AddProductMutationDocument.Instance,
                strategy: global::StrawberryShake.RequestStrategy.Default,
                variables:variables);
        }

        private global::System.Object? FormatName(global::System.String value)
        {
            if (value is null)
            {
                throw new global::System.ArgumentNullException(nameof(value));
            }

            return _stringFormatter.Format(value);
        }

        private global::System.Object? FormatProductNumber(global::System.String value)
        {
            if (value is null)
            {
                throw new global::System.ArgumentNullException(nameof(value));
            }

            return _stringFormatter.Format(value);
        }

        private global::System.Object? FormatMakeFlag(global::System.Boolean value)
        {
            return _booleanFormatter.Format(value);
        }

        private global::System.Object? FormatFinishedGoodsFlag(global::System.Boolean value)
        {
            return _booleanFormatter.Format(value);
        }

        private global::System.Object? FormatSafetyStockLevel(global::System.Int16 value)
        {
            return _shortFormatter.Format(value);
        }

        private global::System.Object? FormatReorderPoint(global::System.Int16 value)
        {
            return _shortFormatter.Format(value);
        }

        private global::System.Object? FormatStandardCost(global::System.Decimal value)
        {
            return _decimalFormatter.Format(value);
        }

        private global::System.Object? FormatListPrice(global::System.Decimal value)
        {
            return _decimalFormatter.Format(value);
        }

        private global::System.Object? FormatDaysToManufacture(global::System.Int32 value)
        {
            return _intFormatter.Format(value);
        }

        private global::System.Object? FormatSellStartDate(global::System.DateTimeOffset value)
        {
            return _dateTimeFormatter.Format(value);
        }

        global::StrawberryShake.OperationRequest global::StrawberryShake.IOperationRequestFactory.Create(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return CreateRequest(variables!);
        }
    }
}


// IAddProductMutation.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the AddProduct GraphQL operation
    /// <code>
    /// mutation AddProduct($name: String!, $productNumber: String!, $makeFlag: Boolean!, $finishedGoodsFlag: Boolean!, $safetyStockLevel: Short!, $reorderPoint: Short!, $standardCost: Decimal!, $listPrice: Decimal!, $daysToManufacture: Int!, $sellStartDate: DateTime!) {
    ///   addProduct(input: { name: $name, productNumber: $productNumber, makeFlag: $makeFlag, finishedGoodsFlag: $finishedGoodsFlag, safetyStockLevel: $safetyStockLevel, reorderPoint: $reorderPoint, standardCost: $standardCost, listPrice: $listPrice, daysToManufacture: $daysToManufacture, sellStartDate: $sellStartDate }) {
    ///     __typename
    ///     product {
    ///       __typename
    ///       name
    ///       productId
    ///       productNumber
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IAddProductMutation
        : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IAddProductResult>> ExecuteAsync(
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate,
            global::System.Threading.CancellationToken cancellationToken = default);

        global::System.IObservable<global::StrawberryShake.IOperationResult<IAddProductResult>> Watch(
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate,
            global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}


// OnProductAddedSubscriptionDocument.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the OnProductAdded GraphQL operation
    /// <code>
    /// subscription OnProductAdded {
    ///   onProductAdded {
    ///     __typename
    ///     productId
    ///     name
    ///     safetyStockLevel
    ///     daysToManufacture
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class OnProductAddedSubscriptionDocument
        : global::StrawberryShake.IDocument
    {
        private OnProductAddedSubscriptionDocument()
        {
        }

        public static OnProductAddedSubscriptionDocument Instance { get; } = new OnProductAddedSubscriptionDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Subscription;

        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{ 0x73, 0x75, 0x62, 0x73, 0x63, 0x72, 0x69, 0x70, 0x74, 0x69, 0x6f, 0x6e, 0x20, 0x4f, 0x6e, 0x50, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x41, 0x64, 0x64, 0x65, 0x64, 0x20, 0x7b, 0x20, 0x6f, 0x6e, 0x50, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x41, 0x64, 0x64, 0x65, 0x64, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x49, 0x64, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x73, 0x61, 0x66, 0x65, 0x74, 0x79, 0x53, 0x74, 0x6f, 0x63, 0x6b, 0x4c, 0x65, 0x76, 0x65, 0x6c, 0x20, 0x64, 0x61, 0x79, 0x73, 0x54, 0x6f, 0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x20, 0x7d, 0x20, 0x7d };

        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("sha1Hash", "57779f81630dc87b7e32a182853064d866828506");

        public override global::System.String ToString()
        {
            #if NETSTANDARD2_0
            return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
            #else
            return global::System.Text.Encoding.UTF8.GetString(Body);
            #endif
        }
    }
}


// OnProductAddedSubscription.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the OnProductAdded GraphQL operation
    /// <code>
    /// subscription OnProductAdded {
    ///   onProductAdded {
    ///     __typename
    ///     productId
    ///     name
    ///     safetyStockLevel
    ///     daysToManufacture
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class OnProductAddedSubscription
        : global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedSubscription
    {
        private readonly global::StrawberryShake.IOperationExecutor<IOnProductAddedResult> _operationExecutor;

        public OnProductAddedSubscription(global::StrawberryShake.IOperationExecutor<IOnProductAddedResult> operationExecutor)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
        }

        global::System.Type global::StrawberryShake.IOperationRequestFactory.ResultType => typeof(IOnProductAddedResult);

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IOnProductAddedResult>> Watch(global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest();
            return _operationExecutor.Watch(
                request,
                strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest()
        {

            return CreateRequest(null);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {

            return new global::StrawberryShake.OperationRequest(
                id: OnProductAddedSubscriptionDocument.Instance.Hash.Value,
                name: "OnProductAdded",
                document: OnProductAddedSubscriptionDocument.Instance,
                strategy: global::StrawberryShake.RequestStrategy.Default);
        }

        global::StrawberryShake.OperationRequest global::StrawberryShake.IOperationRequestFactory.Create(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return CreateRequest();
        }
    }
}


// IOnProductAddedSubscription.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the OnProductAdded GraphQL operation
    /// <code>
    /// subscription OnProductAdded {
    ///   onProductAdded {
    ///     __typename
    ///     productId
    ///     name
    ///     safetyStockLevel
    ///     daysToManufacture
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IOnProductAddedSubscription
        : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.IObservable<global::StrawberryShake.IOperationResult<IOnProductAddedResult>> Watch(global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}


// UpdateProductMutationDocument.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the UpdateProduct GraphQL operation
    /// <code>
    /// mutation UpdateProduct($productId: Int!, $name: String!, $productNumber: String!, $makeFlag: Boolean!, $finishedGoodsFlag: Boolean!, $safetyStockLevel: Short!, $reorderPoint: Short!, $standardCost: Decimal!, $listPrice: Decimal!, $daysToManufacture: Int!, $sellStartDate: DateTime!) {
    ///   updateProduct(input: { productId: $productId, name: $name, productNumber: $productNumber, makeFlag: $makeFlag, finishedGoodsFlag: $finishedGoodsFlag, safetyStockLevel: $safetyStockLevel, reorderPoint: $reorderPoint, standardCost: $standardCost, listPrice: $listPrice, daysToManufacture: $daysToManufacture, sellStartDate: $sellStartDate }) {
    ///     __typename
    ///     product {
    ///       __typename
    ///       name
    ///       productId
    ///       name
    ///       productNumber
    ///       makeFlag
    ///       finishedGoodsFlag
    ///       safetyStockLevel
    ///       reorderPoint
    ///       standardCost
    ///       listPrice
    ///       daysToManufacture
    ///       sellStartDate
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProductMutationDocument
        : global::StrawberryShake.IDocument
    {
        private UpdateProductMutationDocument()
        {
        }

        public static UpdateProductMutationDocument Instance { get; } = new UpdateProductMutationDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Mutation;

        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{ 0x6d, 0x75, 0x74, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x20, 0x55, 0x70, 0x64, 0x61, 0x74, 0x65, 0x50, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x28, 0x24, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x49, 0x64, 0x3a, 0x20, 0x49, 0x6e, 0x74, 0x21, 0x2c, 0x20, 0x24, 0x6e, 0x61, 0x6d, 0x65, 0x3a, 0x20, 0x53, 0x74, 0x72, 0x69, 0x6e, 0x67, 0x21, 0x2c, 0x20, 0x24, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x4e, 0x75, 0x6d, 0x62, 0x65, 0x72, 0x3a, 0x20, 0x53, 0x74, 0x72, 0x69, 0x6e, 0x67, 0x21, 0x2c, 0x20, 0x24, 0x6d, 0x61, 0x6b, 0x65, 0x46, 0x6c, 0x61, 0x67, 0x3a, 0x20, 0x42, 0x6f, 0x6f, 0x6c, 0x65, 0x61, 0x6e, 0x21, 0x2c, 0x20, 0x24, 0x66, 0x69, 0x6e, 0x69, 0x73, 0x68, 0x65, 0x64, 0x47, 0x6f, 0x6f, 0x64, 0x73, 0x46, 0x6c, 0x61, 0x67, 0x3a, 0x20, 0x42, 0x6f, 0x6f, 0x6c, 0x65, 0x61, 0x6e, 0x21, 0x2c, 0x20, 0x24, 0x73, 0x61, 0x66, 0x65, 0x74, 0x79, 0x53, 0x74, 0x6f, 0x63, 0x6b, 0x4c, 0x65, 0x76, 0x65, 0x6c, 0x3a, 0x20, 0x53, 0x68, 0x6f, 0x72, 0x74, 0x21, 0x2c, 0x20, 0x24, 0x72, 0x65, 0x6f, 0x72, 0x64, 0x65, 0x72, 0x50, 0x6f, 0x69, 0x6e, 0x74, 0x3a, 0x20, 0x53, 0x68, 0x6f, 0x72, 0x74, 0x21, 0x2c, 0x20, 0x24, 0x73, 0x74, 0x61, 0x6e, 0x64, 0x61, 0x72, 0x64, 0x43, 0x6f, 0x73, 0x74, 0x3a, 0x20, 0x44, 0x65, 0x63, 0x69, 0x6d, 0x61, 0x6c, 0x21, 0x2c, 0x20, 0x24, 0x6c, 0x69, 0x73, 0x74, 0x50, 0x72, 0x69, 0x63, 0x65, 0x3a, 0x20, 0x44, 0x65, 0x63, 0x69, 0x6d, 0x61, 0x6c, 0x21, 0x2c, 0x20, 0x24, 0x64, 0x61, 0x79, 0x73, 0x54, 0x6f, 0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x3a, 0x20, 0x49, 0x6e, 0x74, 0x21, 0x2c, 0x20, 0x24, 0x73, 0x65, 0x6c, 0x6c, 0x53, 0x74, 0x61, 0x72, 0x74, 0x44, 0x61, 0x74, 0x65, 0x3a, 0x20, 0x44, 0x61, 0x74, 0x65, 0x54, 0x69, 0x6d, 0x65, 0x21, 0x29, 0x20, 0x7b, 0x20, 0x75, 0x70, 0x64, 0x61, 0x74, 0x65, 0x50, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x28, 0x69, 0x6e, 0x70, 0x75, 0x74, 0x3a, 0x20, 0x7b, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x49, 0x64, 0x3a, 0x20, 0x24, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x49, 0x64, 0x2c, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x3a, 0x20, 0x24, 0x6e, 0x61, 0x6d, 0x65, 0x2c, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x4e, 0x75, 0x6d, 0x62, 0x65, 0x72, 0x3a, 0x20, 0x24, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x4e, 0x75, 0x6d, 0x62, 0x65, 0x72, 0x2c, 0x20, 0x6d, 0x61, 0x6b, 0x65, 0x46, 0x6c, 0x61, 0x67, 0x3a, 0x20, 0x24, 0x6d, 0x61, 0x6b, 0x65, 0x46, 0x6c, 0x61, 0x67, 0x2c, 0x20, 0x66, 0x69, 0x6e, 0x69, 0x73, 0x68, 0x65, 0x64, 0x47, 0x6f, 0x6f, 0x64, 0x73, 0x46, 0x6c, 0x61, 0x67, 0x3a, 0x20, 0x24, 0x66, 0x69, 0x6e, 0x69, 0x73, 0x68, 0x65, 0x64, 0x47, 0x6f, 0x6f, 0x64, 0x73, 0x46, 0x6c, 0x61, 0x67, 0x2c, 0x20, 0x73, 0x61, 0x66, 0x65, 0x74, 0x79, 0x53, 0x74, 0x6f, 0x63, 0x6b, 0x4c, 0x65, 0x76, 0x65, 0x6c, 0x3a, 0x20, 0x24, 0x73, 0x61, 0x66, 0x65, 0x74, 0x79, 0x53, 0x74, 0x6f, 0x63, 0x6b, 0x4c, 0x65, 0x76, 0x65, 0x6c, 0x2c, 0x20, 0x72, 0x65, 0x6f, 0x72, 0x64, 0x65, 0x72, 0x50, 0x6f, 0x69, 0x6e, 0x74, 0x3a, 0x20, 0x24, 0x72, 0x65, 0x6f, 0x72, 0x64, 0x65, 0x72, 0x50, 0x6f, 0x69, 0x6e, 0x74, 0x2c, 0x20, 0x73, 0x74, 0x61, 0x6e, 0x64, 0x61, 0x72, 0x64, 0x43, 0x6f, 0x73, 0x74, 0x3a, 0x20, 0x24, 0x73, 0x74, 0x61, 0x6e, 0x64, 0x61, 0x72, 0x64, 0x43, 0x6f, 0x73, 0x74, 0x2c, 0x20, 0x6c, 0x69, 0x73, 0x74, 0x50, 0x72, 0x69, 0x63, 0x65, 0x3a, 0x20, 0x24, 0x6c, 0x69, 0x73, 0x74, 0x50, 0x72, 0x69, 0x63, 0x65, 0x2c, 0x20, 0x64, 0x61, 0x79, 0x73, 0x54, 0x6f, 0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x3a, 0x20, 0x24, 0x64, 0x61, 0x79, 0x73, 0x54, 0x6f, 0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x2c, 0x20, 0x73, 0x65, 0x6c, 0x6c, 0x53, 0x74, 0x61, 0x72, 0x74, 0x44, 0x61, 0x74, 0x65, 0x3a, 0x20, 0x24, 0x73, 0x65, 0x6c, 0x6c, 0x53, 0x74, 0x61, 0x72, 0x74, 0x44, 0x61, 0x74, 0x65, 0x20, 0x7d, 0x29, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x49, 0x64, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x70, 0x72, 0x6f, 0x64, 0x75, 0x63, 0x74, 0x4e, 0x75, 0x6d, 0x62, 0x65, 0x72, 0x20, 0x6d, 0x61, 0x6b, 0x65, 0x46, 0x6c, 0x61, 0x67, 0x20, 0x66, 0x69, 0x6e, 0x69, 0x73, 0x68, 0x65, 0x64, 0x47, 0x6f, 0x6f, 0x64, 0x73, 0x46, 0x6c, 0x61, 0x67, 0x20, 0x73, 0x61, 0x66, 0x65, 0x74, 0x79, 0x53, 0x74, 0x6f, 0x63, 0x6b, 0x4c, 0x65, 0x76, 0x65, 0x6c, 0x20, 0x72, 0x65, 0x6f, 0x72, 0x64, 0x65, 0x72, 0x50, 0x6f, 0x69, 0x6e, 0x74, 0x20, 0x73, 0x74, 0x61, 0x6e, 0x64, 0x61, 0x72, 0x64, 0x43, 0x6f, 0x73, 0x74, 0x20, 0x6c, 0x69, 0x73, 0x74, 0x50, 0x72, 0x69, 0x63, 0x65, 0x20, 0x64, 0x61, 0x79, 0x73, 0x54, 0x6f, 0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x20, 0x73, 0x65, 0x6c, 0x6c, 0x53, 0x74, 0x61, 0x72, 0x74, 0x44, 0x61, 0x74, 0x65, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x7d };

        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("sha1Hash", "be434d179716c66f08931e70e9204106c2909b1c");

        public override global::System.String ToString()
        {
            #if NETSTANDARD2_0
            return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
            #else
            return global::System.Text.Encoding.UTF8.GetString(Body);
            #endif
        }
    }
}


// UpdateProductMutation.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the UpdateProduct GraphQL operation
    /// <code>
    /// mutation UpdateProduct($productId: Int!, $name: String!, $productNumber: String!, $makeFlag: Boolean!, $finishedGoodsFlag: Boolean!, $safetyStockLevel: Short!, $reorderPoint: Short!, $standardCost: Decimal!, $listPrice: Decimal!, $daysToManufacture: Int!, $sellStartDate: DateTime!) {
    ///   updateProduct(input: { productId: $productId, name: $name, productNumber: $productNumber, makeFlag: $makeFlag, finishedGoodsFlag: $finishedGoodsFlag, safetyStockLevel: $safetyStockLevel, reorderPoint: $reorderPoint, standardCost: $standardCost, listPrice: $listPrice, daysToManufacture: $daysToManufacture, sellStartDate: $sellStartDate }) {
    ///     __typename
    ///     product {
    ///       __typename
    ///       name
    ///       productId
    ///       name
    ///       productNumber
    ///       makeFlag
    ///       finishedGoodsFlag
    ///       safetyStockLevel
    ///       reorderPoint
    ///       standardCost
    ///       listPrice
    ///       daysToManufacture
    ///       sellStartDate
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProductMutation
        : global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductMutation
    {
        private readonly global::StrawberryShake.IOperationExecutor<IUpdateProductResult> _operationExecutor;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _intFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _stringFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _booleanFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _shortFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _decimalFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _dateTimeFormatter;

        public UpdateProductMutation(
            global::StrawberryShake.IOperationExecutor<IUpdateProductResult> operationExecutor,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
            _intFormatter = serializerResolver.GetInputValueFormatter("Int");
            _stringFormatter = serializerResolver.GetInputValueFormatter("String");
            _booleanFormatter = serializerResolver.GetInputValueFormatter("Boolean");
            _shortFormatter = serializerResolver.GetInputValueFormatter("Short");
            _decimalFormatter = serializerResolver.GetInputValueFormatter("Decimal");
            _dateTimeFormatter = serializerResolver.GetInputValueFormatter("DateTime");
        }

        global::System.Type global::StrawberryShake.IOperationRequestFactory.ResultType => typeof(IUpdateProductResult);

        public async global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IUpdateProductResult>> ExecuteAsync(
            global::System.Int32 productId,
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = CreateRequest(
                productId,
                name,
                productNumber,
                makeFlag,
                finishedGoodsFlag,
                safetyStockLevel,
                reorderPoint,
                standardCost,
                listPrice,
                daysToManufacture,
                sellStartDate);

            return await _operationExecutor
                .ExecuteAsync(
                    request,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IUpdateProductResult>> Watch(
            global::System.Int32 productId,
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate,
            global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest(
                productId,
                name,
                productNumber,
                makeFlag,
                finishedGoodsFlag,
                safetyStockLevel,
                reorderPoint,
                standardCost,
                listPrice,
                daysToManufacture,
                sellStartDate);
            return _operationExecutor.Watch(
                request,
                strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(
            global::System.Int32 productId,
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate)
        {
            var variables = new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>();

            variables.Add(
                "productId",
                FormatProductId(productId));
            variables.Add(
                "name",
                FormatName(name));
            variables.Add(
                "productNumber",
                FormatProductNumber(productNumber));
            variables.Add(
                "makeFlag",
                FormatMakeFlag(makeFlag));
            variables.Add(
                "finishedGoodsFlag",
                FormatFinishedGoodsFlag(finishedGoodsFlag));
            variables.Add(
                "safetyStockLevel",
                FormatSafetyStockLevel(safetyStockLevel));
            variables.Add(
                "reorderPoint",
                FormatReorderPoint(reorderPoint));
            variables.Add(
                "standardCost",
                FormatStandardCost(standardCost));
            variables.Add(
                "listPrice",
                FormatListPrice(listPrice));
            variables.Add(
                "daysToManufacture",
                FormatDaysToManufacture(daysToManufacture));
            variables.Add(
                "sellStartDate",
                FormatSellStartDate(sellStartDate));

            return CreateRequest(variables);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {

            return new global::StrawberryShake.OperationRequest(
                id: UpdateProductMutationDocument.Instance.Hash.Value,
                name: "UpdateProduct",
                document: UpdateProductMutationDocument.Instance,
                strategy: global::StrawberryShake.RequestStrategy.Default,
                variables:variables);
        }

        private global::System.Object? FormatProductId(global::System.Int32 value)
        {
            return _intFormatter.Format(value);
        }

        private global::System.Object? FormatName(global::System.String value)
        {
            if (value is null)
            {
                throw new global::System.ArgumentNullException(nameof(value));
            }

            return _stringFormatter.Format(value);
        }

        private global::System.Object? FormatProductNumber(global::System.String value)
        {
            if (value is null)
            {
                throw new global::System.ArgumentNullException(nameof(value));
            }

            return _stringFormatter.Format(value);
        }

        private global::System.Object? FormatMakeFlag(global::System.Boolean value)
        {
            return _booleanFormatter.Format(value);
        }

        private global::System.Object? FormatFinishedGoodsFlag(global::System.Boolean value)
        {
            return _booleanFormatter.Format(value);
        }

        private global::System.Object? FormatSafetyStockLevel(global::System.Int16 value)
        {
            return _shortFormatter.Format(value);
        }

        private global::System.Object? FormatReorderPoint(global::System.Int16 value)
        {
            return _shortFormatter.Format(value);
        }

        private global::System.Object? FormatStandardCost(global::System.Decimal value)
        {
            return _decimalFormatter.Format(value);
        }

        private global::System.Object? FormatListPrice(global::System.Decimal value)
        {
            return _decimalFormatter.Format(value);
        }

        private global::System.Object? FormatDaysToManufacture(global::System.Int32 value)
        {
            return _intFormatter.Format(value);
        }

        private global::System.Object? FormatSellStartDate(global::System.DateTimeOffset value)
        {
            return _dateTimeFormatter.Format(value);
        }

        global::StrawberryShake.OperationRequest global::StrawberryShake.IOperationRequestFactory.Create(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return CreateRequest(variables!);
        }
    }
}


// IUpdateProductMutation.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the operation service of the UpdateProduct GraphQL operation
    /// <code>
    /// mutation UpdateProduct($productId: Int!, $name: String!, $productNumber: String!, $makeFlag: Boolean!, $finishedGoodsFlag: Boolean!, $safetyStockLevel: Short!, $reorderPoint: Short!, $standardCost: Decimal!, $listPrice: Decimal!, $daysToManufacture: Int!, $sellStartDate: DateTime!) {
    ///   updateProduct(input: { productId: $productId, name: $name, productNumber: $productNumber, makeFlag: $makeFlag, finishedGoodsFlag: $finishedGoodsFlag, safetyStockLevel: $safetyStockLevel, reorderPoint: $reorderPoint, standardCost: $standardCost, listPrice: $listPrice, daysToManufacture: $daysToManufacture, sellStartDate: $sellStartDate }) {
    ///     __typename
    ///     product {
    ///       __typename
    ///       name
    ///       productId
    ///       name
    ///       productNumber
    ///       makeFlag
    ///       finishedGoodsFlag
    ///       safetyStockLevel
    ///       reorderPoint
    ///       standardCost
    ///       listPrice
    ///       daysToManufacture
    ///       sellStartDate
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IUpdateProductMutation
        : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IUpdateProductResult>> ExecuteAsync(
            global::System.Int32 productId,
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate,
            global::System.Threading.CancellationToken cancellationToken = default);

        global::System.IObservable<global::StrawberryShake.IOperationResult<IUpdateProductResult>> Watch(
            global::System.Int32 productId,
            global::System.String name,
            global::System.String productNumber,
            global::System.Boolean makeFlag,
            global::System.Boolean finishedGoodsFlag,
            global::System.Int16 safetyStockLevel,
            global::System.Int16 reorderPoint,
            global::System.Decimal standardCost,
            global::System.Decimal listPrice,
            global::System.Int32 daysToManufacture,
            global::System.DateTimeOffset sellStartDate,
            global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}


// AddProductBuilder.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProductBuilder
        : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Boolean, global::System.Boolean> _booleanParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int16, global::System.Int16> _shortParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Decimal, global::System.Decimal> _decimalParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int32, global::System.Int32> _intParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.DateTimeOffset> _dateTimeParser;

        public AddProductBuilder(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityIdSerializer idSerializer,
            global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult> resultDataFactory,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer
                 ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory
                 ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String")
                 ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
            _booleanParser = serializerResolver.GetLeafValueParser<global::System.Boolean, global::System.Boolean>("Boolean")
                 ?? throw new global::System.ArgumentException("No serializer for type `Boolean` found.");
            _shortParser = serializerResolver.GetLeafValueParser<global::System.Int16, global::System.Int16>("Short")
                 ?? throw new global::System.ArgumentException("No serializer for type `Short` found.");
            _decimalParser = serializerResolver.GetLeafValueParser<global::System.Decimal, global::System.Decimal>("Decimal")
                 ?? throw new global::System.ArgumentException("No serializer for type `Decimal` found.");
            _intParser = serializerResolver.GetLeafValueParser<global::System.Int32, global::System.Int32>("Int")
                 ?? throw new global::System.ArgumentException("No serializer for type `Int` found.");
            _dateTimeParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.DateTimeOffset>("DateTime")
                 ?? throw new global::System.ArgumentException("No serializer for type `DateTime` found.");
        }

        public global::StrawberryShake.IOperationResult<IAddProductResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (IAddProductResult Result, AddProductResultInfo Info)? data = null;
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.IClientError>? errors = null;

            try
            {
                if (response.Body != null)
                {
                    if (response.Body.RootElement.TryGetProperty("data", out global::System.Text.Json.JsonElement dataElement) && dataElement.ValueKind == global::System.Text.Json.JsonValueKind.Object)
                    {
                        data = BuildData(dataElement);
                    }
                    if (response.Body.RootElement.TryGetProperty("errors", out global::System.Text.Json.JsonElement errorsElement))
                    {
                        errors = global::StrawberryShake.Json.JsonErrorParser.ParseErrors(errorsElement);
                    }
                }
            }
            catch(global::System.Exception ex)
            {
                errors = new global::StrawberryShake.IClientError[] {
                    new global::StrawberryShake.ClientError(
                        ex.Message,
                        exception: ex)
                };
            }

            return new global::StrawberryShake.OperationResult<IAddProductResult>(
                data?.Result,
                data?.Info,
                _resultDataFactory,
                errors);
        }

        private (IAddProductResult, AddProductResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default!;

            _entityStore.Update(session => 
            {

                snapshot = session.CurrentSnapshot;
            });

            var resultInfo = new AddProductResultInfo(
                DeserializeNonNullableIAddProduct_AddProduct(
                    global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                        obj,
                        "addProduct")),
                entityIds,
                snapshot.Version);

            return (
                _resultDataFactory.Create(resultInfo),
                resultInfo
            );
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AddProductPayloadData DeserializeNonNullableIAddProduct_AddProduct(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value
                .GetProperty("__typename")
                .GetString();

            if (typename?.Equals("AddProductPayload", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AddProductPayloadData(
                    typename,
                    product: DeserializeIAddProduct_AddProduct_Product(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "product")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData? DeserializeIAddProduct_AddProduct_Product(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            var typename = obj.Value
                .GetProperty("__typename")
                .GetString();

            if (typename?.Equals("ProductDto", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData(
                    typename,
                    name: DeserializeNonNullableString(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "name")),
                    productId: DeserializeNonNullableInt32(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "productId")),
                    productNumber: DeserializeNonNullableString(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "productNumber")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.String DeserializeNonNullableString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Int32 DeserializeNonNullableInt32(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _intParser.Parse(obj.Value.GetInt32()!);
        }
    }
}


// OnProductAddedBuilder.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class OnProductAddedBuilder
        : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int32, global::System.Int32> _intParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int16, global::System.Int16> _shortParser;

        public OnProductAddedBuilder(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityIdSerializer idSerializer,
            global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult> resultDataFactory,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer
                 ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory
                 ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _intParser = serializerResolver.GetLeafValueParser<global::System.Int32, global::System.Int32>("Int")
                 ?? throw new global::System.ArgumentException("No serializer for type `Int` found.");
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String")
                 ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
            _shortParser = serializerResolver.GetLeafValueParser<global::System.Int16, global::System.Int16>("Short")
                 ?? throw new global::System.ArgumentException("No serializer for type `Short` found.");
        }

        public global::StrawberryShake.IOperationResult<IOnProductAddedResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (IOnProductAddedResult Result, OnProductAddedResultInfo Info)? data = null;
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.IClientError>? errors = null;

            try
            {
                if (response.Body != null)
                {
                    if (response.Body.RootElement.TryGetProperty("data", out global::System.Text.Json.JsonElement dataElement) && dataElement.ValueKind == global::System.Text.Json.JsonValueKind.Object)
                    {
                        data = BuildData(dataElement);
                    }
                    if (response.Body.RootElement.TryGetProperty("errors", out global::System.Text.Json.JsonElement errorsElement))
                    {
                        errors = global::StrawberryShake.Json.JsonErrorParser.ParseErrors(errorsElement);
                    }
                }
            }
            catch(global::System.Exception ex)
            {
                errors = new global::StrawberryShake.IClientError[] {
                    new global::StrawberryShake.ClientError(
                        ex.Message,
                        exception: ex)
                };
            }

            return new global::StrawberryShake.OperationResult<IOnProductAddedResult>(
                data?.Result,
                data?.Info,
                _resultDataFactory,
                errors);
        }

        private (IOnProductAddedResult, OnProductAddedResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default!;

            _entityStore.Update(session => 
            {

                snapshot = session.CurrentSnapshot;
            });

            var resultInfo = new OnProductAddedResultInfo(
                DeserializeNonNullableIOnProductAdded_OnProductAdded(
                    global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                        obj,
                        "onProductAdded")),
                entityIds,
                snapshot.Version);

            return (
                _resultDataFactory.Create(resultInfo),
                resultInfo
            );
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData DeserializeNonNullableIOnProductAdded_OnProductAdded(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value
                .GetProperty("__typename")
                .GetString();

            if (typename?.Equals("ProductDto", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData(
                    typename,
                    productId: DeserializeNonNullableInt32(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "productId")),
                    name: DeserializeNonNullableString(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "name")),
                    safetyStockLevel: DeserializeNonNullableInt16(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "safetyStockLevel")),
                    daysToManufacture: DeserializeNonNullableInt32(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "daysToManufacture")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.Int32 DeserializeNonNullableInt32(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _intParser.Parse(obj.Value.GetInt32()!);
        }

        private global::System.String DeserializeNonNullableString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Int16 DeserializeNonNullableInt16(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _shortParser.Parse(obj.Value.GetInt16()!);
        }
    }
}


// UpdateProductBuilder.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProductBuilder
        : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int32, global::System.Int32> _intParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Boolean, global::System.Boolean> _booleanParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int16, global::System.Int16> _shortParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Decimal, global::System.Decimal> _decimalParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.DateTimeOffset> _dateTimeParser;

        public UpdateProductBuilder(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityIdSerializer idSerializer,
            global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult> resultDataFactory,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer
                 ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory
                 ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _intParser = serializerResolver.GetLeafValueParser<global::System.Int32, global::System.Int32>("Int")
                 ?? throw new global::System.ArgumentException("No serializer for type `Int` found.");
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String")
                 ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
            _booleanParser = serializerResolver.GetLeafValueParser<global::System.Boolean, global::System.Boolean>("Boolean")
                 ?? throw new global::System.ArgumentException("No serializer for type `Boolean` found.");
            _shortParser = serializerResolver.GetLeafValueParser<global::System.Int16, global::System.Int16>("Short")
                 ?? throw new global::System.ArgumentException("No serializer for type `Short` found.");
            _decimalParser = serializerResolver.GetLeafValueParser<global::System.Decimal, global::System.Decimal>("Decimal")
                 ?? throw new global::System.ArgumentException("No serializer for type `Decimal` found.");
            _dateTimeParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.DateTimeOffset>("DateTime")
                 ?? throw new global::System.ArgumentException("No serializer for type `DateTime` found.");
        }

        public global::StrawberryShake.IOperationResult<IUpdateProductResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (IUpdateProductResult Result, UpdateProductResultInfo Info)? data = null;
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.IClientError>? errors = null;

            try
            {
                if (response.Body != null)
                {
                    if (response.Body.RootElement.TryGetProperty("data", out global::System.Text.Json.JsonElement dataElement) && dataElement.ValueKind == global::System.Text.Json.JsonValueKind.Object)
                    {
                        data = BuildData(dataElement);
                    }
                    if (response.Body.RootElement.TryGetProperty("errors", out global::System.Text.Json.JsonElement errorsElement))
                    {
                        errors = global::StrawberryShake.Json.JsonErrorParser.ParseErrors(errorsElement);
                    }
                }
            }
            catch(global::System.Exception ex)
            {
                errors = new global::StrawberryShake.IClientError[] {
                    new global::StrawberryShake.ClientError(
                        ex.Message,
                        exception: ex)
                };
            }

            return new global::StrawberryShake.OperationResult<IUpdateProductResult>(
                data?.Result,
                data?.Info,
                _resultDataFactory,
                errors);
        }

        private (IUpdateProductResult, UpdateProductResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default!;

            _entityStore.Update(session => 
            {

                snapshot = session.CurrentSnapshot;
            });

            var resultInfo = new UpdateProductResultInfo(
                DeserializeNonNullableIUpdateProduct_UpdateProduct(
                    global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                        obj,
                        "updateProduct")),
                entityIds,
                snapshot.Version);

            return (
                _resultDataFactory.Create(resultInfo),
                resultInfo
            );
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.UpdateProductPayloadData DeserializeNonNullableIUpdateProduct_UpdateProduct(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value
                .GetProperty("__typename")
                .GetString();

            if (typename?.Equals("UpdateProductPayload", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.UpdateProductPayloadData(
                    typename,
                    product: DeserializeIUpdateProduct_UpdateProduct_Product(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "product")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData? DeserializeIUpdateProduct_UpdateProduct_Product(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            var typename = obj.Value
                .GetProperty("__typename")
                .GetString();

            if (typename?.Equals("ProductDto", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData(
                    typename,
                    name: DeserializeNonNullableString(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "name")),
                    productId: DeserializeNonNullableInt32(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "productId")),
                    productNumber: DeserializeNonNullableString(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "productNumber")),
                    makeFlag: DeserializeNonNullableBoolean(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "makeFlag")),
                    finishedGoodsFlag: DeserializeNonNullableBoolean(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "finishedGoodsFlag")),
                    safetyStockLevel: DeserializeNonNullableInt16(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "safetyStockLevel")),
                    reorderPoint: DeserializeNonNullableInt16(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "reorderPoint")),
                    standardCost: DeserializeNonNullableDecimal(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "standardCost")),
                    listPrice: DeserializeNonNullableDecimal(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "listPrice")),
                    daysToManufacture: DeserializeNonNullableInt32(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "daysToManufacture")),
                    sellStartDate: DeserializeNonNullableDateTimeOffset(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "sellStartDate")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.String DeserializeNonNullableString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Int32 DeserializeNonNullableInt32(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _intParser.Parse(obj.Value.GetInt32()!);
        }

        private global::System.Boolean DeserializeNonNullableBoolean(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _booleanParser.Parse(obj.Value.GetBoolean()!);
        }

        private global::System.Int16 DeserializeNonNullableInt16(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _shortParser.Parse(obj.Value.GetInt16()!);
        }

        private global::System.Decimal DeserializeNonNullableDecimal(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _decimalParser.Parse(obj.Value.GetDecimal()!);
        }

        private global::System.DateTimeOffset DeserializeNonNullableDateTimeOffset(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _dateTimeParser.Parse(obj.Value.GetString()!);
        }
    }
}


// AddProductPayloadData.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AddProductPayloadData
    {
        public AddProductPayloadData(
            global::System.String __typename,
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData? product = null)
        {
            this.__typename = __typename
                 ?? throw new global::System.ArgumentNullException(nameof(__typename));
            Product = product;
        }

        public global::System.String __typename { get; }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData? Product { get; }
    }
}


// ProductDtoData.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class ProductDtoData
    {
        public ProductDtoData(
            global::System.String __typename,
            global::System.String? name = null,
            global::System.Int32? productId = null,
            global::System.String? productNumber = null,
            global::System.Int16? safetyStockLevel = null,
            global::System.Int32? daysToManufacture = null,
            global::System.Boolean? makeFlag = null,
            global::System.Boolean? finishedGoodsFlag = null,
            global::System.Int16? reorderPoint = null,
            global::System.Decimal? standardCost = null,
            global::System.Decimal? listPrice = null,
            global::System.DateTimeOffset? sellStartDate = null)
        {
            this.__typename = __typename
                 ?? throw new global::System.ArgumentNullException(nameof(__typename));
            Name = name;
            ProductId = productId;
            ProductNumber = productNumber;
            SafetyStockLevel = safetyStockLevel;
            DaysToManufacture = daysToManufacture;
            MakeFlag = makeFlag;
            FinishedGoodsFlag = finishedGoodsFlag;
            ReorderPoint = reorderPoint;
            StandardCost = standardCost;
            ListPrice = listPrice;
            SellStartDate = sellStartDate;
        }

        public global::System.String __typename { get; }

        public global::System.String? Name { get; }

        public global::System.Int32? ProductId { get; }

        public global::System.String? ProductNumber { get; }

        public global::System.Int16? SafetyStockLevel { get; }

        public global::System.Int32? DaysToManufacture { get; }

        public global::System.Boolean? MakeFlag { get; }

        public global::System.Boolean? FinishedGoodsFlag { get; }

        public global::System.Int16? ReorderPoint { get; }

        public global::System.Decimal? StandardCost { get; }

        public global::System.Decimal? ListPrice { get; }

        public global::System.DateTimeOffset? SellStartDate { get; }
    }
}


// UpdateProductPayloadData.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class UpdateProductPayloadData
    {
        public UpdateProductPayloadData(
            global::System.String __typename,
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData? product = null)
        {
            this.__typename = __typename
                 ?? throw new global::System.ArgumentNullException(nameof(__typename));
            Product = product;
        }

        public global::System.String __typename { get; }

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.ProductDtoData? Product { get; }
    }
}


// AdvertureWorksClient.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the AdvertureWorksClient GraphQL client
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AdvertureWorksClient
        : global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAdvertureWorksClient
    {
        private readonly global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductMutation _addProduct;
        private readonly global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedSubscription _onProductAdded;
        private readonly global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductMutation _updateProduct;

        public AdvertureWorksClient(
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductMutation addProduct,
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedSubscription onProductAdded,
            global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductMutation updateProduct)
        {
            _addProduct = addProduct
                 ?? throw new global::System.ArgumentNullException(nameof(addProduct));
            _onProductAdded = onProductAdded
                 ?? throw new global::System.ArgumentNullException(nameof(onProductAdded));
            _updateProduct = updateProduct
                 ?? throw new global::System.ArgumentNullException(nameof(updateProduct));
        }

        public static global::System.String ClientName => "AdvertureWorksClient";

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductMutation AddProduct => _addProduct;

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedSubscription OnProductAdded => _onProductAdded;

        public global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductMutation UpdateProduct => _updateProduct;
    }
}


// IAdvertureWorksClient.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient
{
    /// <summary>
    /// Represents the AdvertureWorksClient GraphQL client
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public interface IAdvertureWorksClient
    {
        global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductMutation AddProduct { get; }

        global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedSubscription OnProductAdded { get; }

        global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductMutation UpdateProduct { get; }
    }
}


// AdvertureWorksClientEntityIdFactory.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AdvertureWorksClientEntityIdFactory
        : global::StrawberryShake.IEntityIdSerializer
    {
        private static readonly global::System.Text.Json.JsonWriterOptions _options = new global::System.Text.Json.JsonWriterOptions(){ Indented = false };

        public global::StrawberryShake.EntityId Parse(global::System.Text.Json.JsonElement obj)
        {
            global::System.String __typename = obj
                .GetProperty("__typename")
                .GetString()!;

            return __typename switch
            {
                _ => throw new global::System.NotSupportedException()
            };
        }

        public global::System.String Format(global::StrawberryShake.EntityId entityId)
        {
            return entityId.Name switch
            {
                _ => throw new global::System.NotSupportedException()
            };
        }
    }
}


// AdvertureWorksClientServiceCollectionExtensions.cs
#nullable enable

namespace Microsoft.Extensions.DependencyInjection
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public static partial class AdvertureWorksClientServiceCollectionExtensions
    {
        public static global::StrawberryShake.IClientBuilder<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AdvertureWorksClientStoreAccessor> AddAdvertureWorksClient(
            this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services,
            global::StrawberryShake.ExecutionStrategy strategy = global::StrawberryShake.ExecutionStrategy.NetworkOnly)
        {
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => 
                {
                    var serviceCollection = ConfigureClientDefault(
                        sp,
                        strategy);

                    return new ClientServiceProvider(
                        global::Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(serviceCollection));
                });

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => new global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AdvertureWorksClientStoreAccessor(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IEntityStore>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IEntityIdSerializer>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.IOperationRequestFactory>>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.IOperationResultDataFactory>>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp))));

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.AddProductMutation>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.OnProductAddedSubscription>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.UpdateProductMutation>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.AdvertureWorksClient>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAdvertureWorksClient>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));

            return new global::StrawberryShake.ClientBuilder<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AdvertureWorksClientStoreAccessor>(
                "AdvertureWorksClient",
                services);
        }

        private static global::Microsoft.Extensions.DependencyInjection.IServiceCollection ConfigureClientDefault(
            global::System.IServiceProvider parentServices,
            global::StrawberryShake.ExecutionStrategy strategy = global::StrawberryShake.ExecutionStrategy.NetworkOnly)
        {
            var services = new global::Microsoft.Extensions.DependencyInjection.ServiceCollection();
            global::Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddSingleton<global::StrawberryShake.IEntityStore, global::StrawberryShake.EntityStore>(services);
            global::Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddSingleton<global::StrawberryShake.IOperationStore>(
                services,
                sp => new global::StrawberryShake.OperationStore(global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IEntityStore>(sp)));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => 
                {
                    var sessionPool = global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.WebSockets.ISessionPool>(parentServices);
                    return new global::StrawberryShake.Transport.WebSockets.WebSocketConnection(async ct => await sessionPool.CreateAsync(
                        "AdvertureWorksClient",
                        ct));
                });
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => 
                {
                    var clientFactory = global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Net.Http.IHttpClientFactory>(parentServices);
                    return new global::StrawberryShake.Transport.Http.HttpConnection(() => clientFactory.CreateClient("AdvertureWorksClient"));
                });


            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.StringSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.BooleanSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ByteSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ShortSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.IntSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.LongSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.FloatSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DecimalSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.UrlSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.UuidSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.IdSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DateTimeSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DateSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ByteArraySerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.TimeSpanSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializerResolver>(
                services,
                sp => new global::StrawberryShake.Serialization.SerializerResolver(
                    global::System.Linq.Enumerable.Concat(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.Serialization.ISerializer>>(
                            parentServices),
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.Serialization.ISerializer>>(
                            sp))));

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult>, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AddProductResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductMutation>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult>, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AddProductBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.Http.HttpConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.AddProductMutation>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAddProductMutation>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.AddProductMutation>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult>, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.OnProductAddedResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedSubscription>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult>, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.OnProductAddedBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.WebSockets.WebSocketConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.OnProductAddedSubscription>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IOnProductAddedSubscription>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.OnProductAddedSubscription>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult>, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.UpdateProductResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductMutation>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult>, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.UpdateProductBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.Http.HttpConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.UpdateProductMutation>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IUpdateProductMutation>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.UpdateProductMutation>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityIdSerializer, global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State.AdvertureWorksClientEntityIdFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.AdvertureWorksClient>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.IAdvertureWorksClient>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.AdvertureWorksClient>(sp));
            return services;
        }

        private class ClientServiceProvider
            : System.IServiceProvider
            , System.IDisposable
        {
            private readonly System.IServiceProvider _provider;

            public ClientServiceProvider(System.IServiceProvider provider)
            {
                _provider = provider;
            }

            public object? GetService(System.Type serviceType)
            {
                return _provider.GetService(serviceType);
            }

            public void Dispose()
            {
                if (_provider is System.IDisposable d)
                {
                    d.Dispose();
                }
            }
        }
    }
}


// AdvertureWorksClientStoreAccessor.cs
#nullable enable

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.AdvertureWorksClient.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.1.0.0")]
    public partial class AdvertureWorksClientStoreAccessor
        : global::StrawberryShake.StoreAccessor
    {
        public AdvertureWorksClientStoreAccessor(
            global::StrawberryShake.IOperationStore operationStore,
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityIdSerializer entityIdSerializer,
            global::System.Collections.Generic.IEnumerable<global::StrawberryShake.IOperationRequestFactory> requestFactories,
            global::System.Collections.Generic.IEnumerable<global::StrawberryShake.IOperationResultDataFactory> resultDataFactories)
            : base(
                operationStore,
                entityStore,
                entityIdSerializer,
                requestFactories,
                resultDataFactories)
        {
        }
    }
}


