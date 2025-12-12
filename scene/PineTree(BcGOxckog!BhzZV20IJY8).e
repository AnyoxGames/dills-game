13
4608499908609
405048457841184 1761863332360394300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 15.6343650817871094,
    "Y": -12.1000385284423828
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405043092932637:1761863331110365100",
  "next_sibling": "405050746843928:1761863332893734400",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405048458097206:1761863332360452900",
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
  "aoid": "405048458212446:1761863332360479800",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405048458097206:1761863332360452900",
    "DefaultRenderer": "405048458262455:1761863332360491400",
    "DepletedRenderer": "405048458244051:1761863332360487100"
  }
},
{
  "cid": 5,
  "aoid": "405048458224873:1761863332360482700",
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
