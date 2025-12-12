13
4930622455809
405110904438914 1761863346910515900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 16.5871124267578125,
    "Y": -0.3651564121246338
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405106469951000:1761863345877275900",
  "next_sibling": "407801550013270:1761863973833719800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405110904758232:1761863346910589600",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "405110904876396:1761863346910617100",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405110904758232:1761863346910589600",
    "DefaultRenderer": "405110904927265:1761863346910629000",
    "DepletedRenderer": "405110904910753:1761863346910625200"
  }
},
{
  "cid": 5,
  "aoid": "405110904890242:1761863346910620300",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
